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
    
    public Vector2 gridPos;

    Block leftNeighbor;
    Block rightNeighbor;
    Block upNeighbor;
    Block downNeighbor;

    List<Block> neighbors = new List<Block>();

    
   
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //this needs real work
    void CheckBelowSelf()
    {
        foreach (Vector2 tileCoord in shape.AllTileCoords)
        {
            //not happy about using the transform position here but
            Vector2 totalCoord = tileCoord + new Vector2(transform.position.x, transform.position.y);

            for (int i = SiteManagerRef.gridSizeY; i >= 0; i--)
            {
                if (SiteManagerRef.grid[(int)totalCoord.x, i] == null)
                    continue;
                else
                {
                    //return grid[col, i].transform.position.y + 1;
                }
            }
        }

        //return 0f;
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
            Vector2 neighborCoord = dir + gridPos;
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

        //print(neighbors.Count);
    }

    public void SetGridPos(int x, int y)
    {
        gridPos = new Vector2(x, y);

        foreach (Vector2 tileCoord in shape.AllTileCoords)
        {
            Vector2 totalCoord = tileCoord + gridPos;
            SiteManagerRef.grid[(int)totalCoord.x, (int)totalCoord.y] = this;
        }
    }

}
