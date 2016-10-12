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

    public GameObject image;

    GameObject ghost;

    [HideInInspector]
    public Vector2 ghostOrigin = new Vector2();

    List<Block> neighbors = new List<Block>();
    public float fallSpeed = 2;

    // Use this for initialization
    void Start () {
        if (!image)
            Debug.LogError(gameObject.name + " has a null Image field! Fix the prefab.");
        else
        {
            SpawnGhost();
            CheckGhostPos();
        }
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

	public void SpawnGhost()
    {
        ghost = Instantiate(image);
        //TODO: depth sort the ghost so it's behind the block.
        //might not work with Jai's images
        foreach (Renderer render in ghost.GetComponentsInChildren<Renderer>())
        {
            float h, s, v;
            Color.RGBToHSV(render.material.color, out h, out s, out v);
            h += 0.5f;
            render.material.color = Color.HSVToRGB(h, s, v);
        }
    }
	// Update is called once per frame
	void Update () {
        
        if (falling)
        {
            transform.position += (Vector3.down * fallSpeed);

            if (transform.position.y < ghostOrigin.y)
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
        CheckGhostPos();
    }

    public void Drop()
    {
        falling = true;
    }

    public void Land()
    {
        falling = false;
        SiteManagerRef.heldBlock = null;

        SetGridPos(ghostOrigin,true);
        UpdateNeighbors();
        Destroy(ghost);
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
                    ghostOrigin = potentialGhostPos;
                    ghost.transform.position = ghostOrigin;
                    if (tileGridPos.y > SiteManagerRef.maxHeight)
                    {
                        print("Over Max Height");
                        return false;
                    }
                    return true;
                }
            }
        }
        ghostOrigin = potentialGhostPos;
        ghost.transform.position = ghostOrigin;
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
