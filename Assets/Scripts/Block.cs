﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : MonoBehaviour {
    //This is the basic script that buildings and toppers derive from.
    [HideInInspector]
    public SiteManager siteManagerRef;
    [HideInInspector]
    public SiteData siteDataRef;
    CameraController camControllerRef;

    public TileData shape;
    List<Block> neighbors = new List<Block>();
    
    public GameObject image;
    [HideInInspector]
    public GameObject ghost;
    public GameObject center;

    public Vector2 gridPositionOfOrigin;
    [HideInInspector]
    public Vector2 ghostOrigin = new Vector2();

    int value = 0;
    [HideInInspector]
    public bool falling = false;
    public float fallSpeed = 2;

    public bool flipped = false;
    Quaternion normalRot = Quaternion.Euler(Vector3.zero);
    Quaternion flippedRot = Quaternion.Euler(0, 180, 0);
    float flipSpeed = 0.1f;

    int leftEdge
    {
        get
        {
            if (siteManagerRef.inShadow)
                return 7;
            else
                return 0;
        }
    }
    int rightEdge
    {
        get
        {
            if (siteManagerRef.inShadow)
                return 11;
            else
                return 4;
        }
    }
    float offset;
    void Awake()
    {
        camControllerRef = FindObjectOfType<CameraController>();
        siteManagerRef = FindObjectOfType<SiteManager>();
        siteDataRef = transform.parent.GetComponent<SiteData>();
        
    }


    // Use this for initialization
    void Start () {
        
        if (!image)
            Debug.LogError(gameObject.name + " has a null Image field! Fix the prefab.");
        else
        {
            SpawnGhost();
            CheckGhostPos();
        }
        
        offset = shape.xLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.localPosition += (Vector3.down * fallSpeed);

            if (transform.localPosition.y < ghostOrigin.y)
            {
                Land();
            }
        }

        if (flipped)
        {
            
            image.transform.localScale  = new Vector3(-1, 1, 1);
            if (ghost)
                ghost.transform.localScale = new Vector3(-1, 1, 1);

            center.transform.localRotation =  flippedRot;
        }
        else
        {
          
            image.transform.localScale  = new Vector3(1, 1, 1);
            if(ghost)
            ghost.transform.localScale = new Vector3(1, 1, 1);
            center.transform.localRotation = normalRot;
        }
    }

    public void SpawnGhost()
    {
        ghost = Instantiate(image,transform.parent);
        //TODO: depth sort the ghost so it's behind the block.
        //TODO: Make the ghosts silhouettes
        SetGhostColor(ColorManager.ghostColor);
    }

    void SetGhostColor(Color color)
    {
        foreach (BuidlingControllerScript control in ghost.GetComponentsInChildren<BuidlingControllerScript>())
        {
            control.SetColor(color);
        }
    }

    public void MoveBlock(Vector2 moveDir)
    {
        Vector2 proposedDestination = gridPositionOfOrigin + moveDir;
        
        if (proposedDestination.x >= leftEdge && proposedDestination.x + shape.xLength <= rightEdge)
        {
            gridPositionOfOrigin = proposedDestination;
            transform.localPosition = gridPositionOfOrigin;
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
        siteManagerRef.heldBlock = null;

        SetGridPos(ghostOrigin,true);

        if (siteManagerRef.inShadow)
        {
            if (CheckTowerHeight() > siteDataRef.shadowTopBlock)
            {
                siteDataRef.shadowTopBlock = CheckTowerHeight();
            }
        }
        else
        {
            if (CheckTowerHeight() > siteDataRef.normalTopBlock)
            {
                siteDataRef.normalTopBlock = CheckTowerHeight();
            }
        }

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

        for (int i = siteManagerRef.maxHeight - 1; i >= 0; i--)
        {
            potentialGhostPos.y = i;

            //go through all tiles if origin is at this height
            foreach (Vector2 tileCoords in shape.AllTileCoords)
            {
                //print(leftEdge);
                Tile currentTile = shape.col[(int)tileCoords.x].row[(int)tileCoords.y];
                Vector2 tileGridPos = tileCoords + potentialGhostPos;

                //if there is something overlapping the space
                if (siteDataRef.grid[(int)tileGridPos.x, (int)tileGridPos.y])
                {
                    //ghost should move up, then check down.
                    potentialGhostPos.y += 1;
                    ghostOrigin = potentialGhostPos;
                    
                    ghost.transform.localPosition = ghostOrigin;
                    if (flipped)
                        ghost.transform.Translate(new Vector3(offset, 0, 0));
                    return CheckMoveValidity();
                }
            }
        }
        //If the checker reaches the floor
        SetGhostColor(ColorManager.ghostColor);
        ghostOrigin = potentialGhostPos;
        
        ghost.transform.localPosition = ghostOrigin;
        if (flipped)
            ghost.transform.Translate(new Vector3(offset, 0, 0))    ;
        return true;
    }

    bool CheckMoveValidity()
    {
        foreach (Vector2 tileCoords in shape.AllTileCoords)
        {
            Vector2 tileGridPos = tileCoords + ghostOrigin + Vector2.down;
            //if any part of the shape is above the max height
            if (tileGridPos.y > siteManagerRef.maxHeight)
            {
                return false;
            }

            //check the bottom row
            if (tileCoords.y == 0)
            {
                Tile currentTile = shape.col[(int)tileCoords.x].row[(int)tileCoords.y];
                
                //do nothing cause NoDown
                if (currentTile != Tile.NoDown)
                {
                    Block foundBlock = siteDataRef.grid[(int)tileGridPos.x, (int)tileGridPos.y];
                    //if a block is found
                    if (foundBlock != null)
                    {
                        Vector2 foundTileCoord = tileGridPos - foundBlock.gridPositionOfOrigin;
                        Tile foundTile = foundBlock.shape.col[(int)foundTileCoord.x].row[(int)foundTileCoord.y];
                        
                        //if one block is above a solid, move is valid
                        if (foundTile == Tile.Solid || foundTile == Tile.NoDown)
                        {
                            SetGhostColor(ColorManager.ghostColor);
                            return true;
                        }
                    }
                }
            }
        }
        //if you've been through all tiles and not found a solid
        SetGhostColor(ColorManager.invalidMoveColor);
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
            if(neighborCoord.x < 0 || neighborCoord.x > siteDataRef.grid.GetLength(0) - 1 ||
                neighborCoord.y < 0 || neighborCoord.y > siteDataRef.grid.GetLength(1) - 1)
                continue;

            Block maybeNeighbor = siteDataRef.grid[(int)neighborCoord.x, (int)neighborCoord.y];
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
        transform.localPosition = gridPositionOfOrigin;

        if (onGrid)
        {
            foreach (Vector2 tileCoord in shape.AllTileCoords)
            {
                Vector2 newCoord = tileCoord + gridPositionOfOrigin;
                siteDataRef.grid[(int)newCoord.x, (int)newCoord.y] = this;
            }
        }
    }

    public void FlipHorizontal()
    {
        if (!flipped)
        {
            //when you flip it
            flipped = true;
            image.transform.Translate(offset, 0, 0);
            ghost.transform.Translate(offset, 0, 0);
        }
        else
        {
            //when it's flipped back
            flipped = false;
            image.transform.Translate(-offset, 0, 0);
            ghost.transform.Translate(-offset, 0, 0);
        }
        shape.FlipHorizontal();

        CheckGhostPos();
    }

    int CheckTowerHeight()
    {
        return (int)(gridPositionOfOrigin.y + shape.yLength + 1);
    }

}