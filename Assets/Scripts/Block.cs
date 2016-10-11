using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour {
    //This is the basic script that buildings and toppers derive from.
    //TODO: I have a worldspace/localspace issue.
    [HideInInspector]
    public SiteManager SiteManagerRef;
    public TileData shape;

    [HideInInspector]
    public int xLength = 0;
    [HideInInspector]
    public int yLength = 0;

    int value = 0;
    [HideInInspector]
    public bool falling = false;
    
  
    public Vector2 gridPositionOfOrigin;

    [HideInInspector]
    public Vector2 ghostPos = new Vector2();

    List<Block> neighbors = new List<Block>();
    public float fallSpeed = 2;

    // Use this for initialization
    void Start () {
        //TODO: consider using a vector2 somehow
        //TODO: find a way of generalizing this foreach, i'm using it very frequently
        //TODO: serialize this or put it in shape?
        foreach (Vector2 tile in shape.AllTileCoords)
        {
            if(tile.x > xLength)
            {
                xLength = (int)tile.x;
            }
            if (tile.y> yLength)
            {
                yLength = (int)tile.y;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (falling)
        {
            transform.position += (Vector3.down * fallSpeed);

            if (transform.position.y < ghostPos.y)
            {
                Land();
            }
        }
    }

    public void MoveBlock(Vector2 moveDir)
    {
        Vector2 proposedDestination = gridPositionOfOrigin + moveDir;
        
        if (proposedDestination.x >= 0 && proposedDestination.x + xLength < 5)
        {
            gridPositionOfOrigin = proposedDestination;
            transform.position = gridPositionOfOrigin;
        }
    }

    public void Drop()
    {
        falling = true;
    }

    public void Land()
    {
        falling = false;
        SiteManagerRef.heldBlock = null;

        SetGridPos(ghostPos,true);
        UpdateNeighbors();
    }

    public void CheckBelowSelf(out GhostInfo newGhostInfo)
    {
        newGhostInfo.ghostOriginCoord = gridPositionOfOrigin;
        int ghostHeight = 0;

        foreach (Vector2 tileCoord in shape.AllTileCoords)
        {
            Vector2 tileGridCoord = tileCoord + gridPositionOfOrigin;
            int newGhostHeight = 0;

            //go down this tile's column
            for (int i = SiteManagerRef.maxHeight -1; i >=0 ; i--)
            {
                if (SiteManagerRef.grid[(int)tileGridCoord.x, i] != null)
                {
                    //there is something in this space
                    if (SiteManagerRef.grid[(int)tileGridCoord.x, i] != this)
                    {
                        //need to set height as 1 above this, if it's larger than ghostheight
                        if (i + 1 > newGhostHeight)
                            newGhostHeight = i + 1;
                    }
                }
            }
            if (newGhostHeight > ghostHeight)
                ghostHeight = newGhostHeight;
        }
            newGhostInfo.ghostOriginCoord.y = ghostHeight;
    }

    /// <summary>
    /// Returns true if position is valid.
    /// </summary>
    /// <returns></returns>
    public bool CheckGhostPos()
    {
        Vector2 potentialGhostPos = new Vector2(gridPositionOfOrigin.x, 0);

        for (int i = SiteManagerRef.maxHeight - 1; i >= 0; i--)
        {
            potentialGhostPos.y = i;
            foreach (Vector2 tile in shape.AllTileCoords)
            {
                Vector2 tileGridPos = tile + potentialGhostPos;
                if (SiteManagerRef.grid[(int)tileGridPos.x, (int)tileGridPos.y] &&
                    SiteManagerRef.grid[(int)tileGridPos.x, (int)tileGridPos.y]!= this)
                {
                    print("Found a tile: " + potentialGhostPos);
                    potentialGhostPos.y += 1;
                    ghostPos = potentialGhostPos;

                    if (tileGridPos.y > SiteManagerRef.maxHeight)
                    {
                        print("Over Max Height");
                        return false;
                    }
                    return true;
                }
            }
        }
        print("bottom level");
        ghostPos = potentialGhostPos;
        return true;
    }
    
    public void UpdateNeighbors()
    {
        Vector2[] dirs = {
            new Vector2(-1,0),
            new Vector2(0,-1),
            new Vector2(1,0),
            new Vector2(0,1)};

        foreach(Vector2 dir in dirs)
        {
            Vector2 neighborCoord = dir + gridPositionOfOrigin;
            if(neighborCoord.x < 0 || neighborCoord.x > SiteManagerRef.grid.GetLength(0) - 1 ||
                neighborCoord.y < 0 || neighborCoord.y > SiteManagerRef.grid.GetLength(1) - 1)
                continue;

            Block maybeNeighbor = SiteManagerRef.grid[(int)neighborCoord.x, (int)neighborCoord.y];
            if (maybeNeighbor != null)
            {
                neighbors.Add(maybeNeighbor);
                maybeNeighbor.neighbors.Add(this);
            }
        }
    }

    public void SetGridPos(Vector2 newPos, bool onGrid)
    {
        gridPositionOfOrigin = newPos;

        transform.position = gridPositionOfOrigin;

        if (onGrid)
        {
            foreach (Vector2 tileCoord in shape.AllTileCoords)
            {
                Vector2 newCoord = tileCoord + gridPositionOfOrigin;
                SiteManagerRef.grid[(int)newCoord.x, (int)newCoord.y] = this;
            }
        }
    }

}

public struct GhostInfo
{
    /// <summary>
    /// The Grid Coord that will be used if the ghost is dropped.
    /// </summary>
    public Vector2 ghostOriginCoord;
}
