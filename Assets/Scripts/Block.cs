using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour {
    //This is the basic script that buildings and toppers derive from.
    [HideInInspector]
    public SiteManager SiteManagerRef;
    public TileData shape;

    public int xLength = 0;
    public int yLength = 0;

    int value = 0;
    public bool falling = false;
    
    public Vector2 gridPositionOfOrigin;
    
    List<Block> neighbors = new List<Block>();

   
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Drop()
    {
        falling = true;
    }

    public bool CheckBelowSelf(out GhostInfo newGhostInfo)
    {
        newGhostInfo.didCollide = false;
        newGhostInfo.checkingTileCoord = Vector2.zero;
        newGhostInfo.hitTileCoord = Vector2.zero;

        foreach (Vector2 tileCoord in shape.AllTileCoords)
        {
            Vector2 currentGridCoord = tileCoord + gridPositionOfOrigin;
            for (int i = SiteManagerRef.gridSizeY -1; i >=0 ; i--)
            {
                if (SiteManagerRef.grid[(int)currentGridCoord.x, i] == null)
                    //there is nothing in the checked space
                    continue;
                else
                {
                    //there is something in this space
                    if (SiteManagerRef.grid[(int)currentGridCoord.x, i] == this)
                    {
                        print("collided with self I think");
                    }
                    else
                    {
                        newGhostInfo.didCollide = true;
                        newGhostInfo.checkingTileCoord = tileCoord;
                        newGhostInfo.hitTileCoord = currentGridCoord;
                        return true;
                    }
                    
                }
            }

        }
        return false;
    }

    public bool CheckCollisionOnGrid(out TileCollision newCollisionInfo)
    {
        newCollisionInfo.didCollide = false;
        newCollisionInfo.checkingTileCoord = Vector2.zero;
        newCollisionInfo.hitTileCoord = Vector2.zero;

        foreach (Vector2 tileCoord in shape.AllTileCoords)
        {
            Vector2 currentTotalCoord = tileCoord + gridPositionOfOrigin;
            for (int i = 0; i < SiteManagerRef.gridSizeY; i++)
            {
                if (SiteManagerRef.grid[(int)currentTotalCoord.x, i] == null)
                    //there is nothing in the checked space
                    continue;
                else
                {
                    //there is something in this space
                    if (SiteManagerRef.grid[(int)currentTotalCoord.x, i] == this)
                    {
                        print("collided with self I think");
                    }
                    newCollisionInfo.didCollide = true;
                    newCollisionInfo.checkingTileCoord = tileCoord;
                    newCollisionInfo.hitTileCoord = currentTotalCoord;
                    return true;
                }
            }
         
        }
        return false;
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

    public void MoveBlock(Vector2 moveDir)
    {

        SetGridPos(gridPositionOfOrigin + moveDir);
    }

    public void SetGridPos(Vector2 newPos)
    {
        gridPositionOfOrigin = newPos;

        transform.localPosition = gridPositionOfOrigin;
        foreach (Vector2 tileCoord in shape.AllTileCoords)
        {
            Vector2 totalCoord = tileCoord + gridPositionOfOrigin;
            SiteManagerRef.grid[(int)totalCoord.x, (int)totalCoord.y] = this;
        }
    }

}
public struct GhostInfo
{
    /// <summary>
    /// true if collision exists.
    /// </summary>
    public bool didCollide;
    /// <summary>
    /// The grid Coord of the tile that checked.
    /// </summary>
    public Vector2 checkingTileCoord;
    /// <summary>
    /// The grid Coord of the tile that was hit.
    /// </summary>
    public Vector2 hitTileCoord;
}

public struct TileCollision
{
    /// <summary>
    /// true if collision exists.
    /// </summary>
    public bool didCollide;
    /// <summary>
    /// The grid Coord of the tile that checked.
    /// </summary>
    public Vector2 checkingTileCoord;
    /// <summary>
    /// The grid Coord of the tile that was hit.
    /// </summary>
    public Vector2 hitTileCoord;
}
