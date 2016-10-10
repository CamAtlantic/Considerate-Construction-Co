using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SiteManager : MonoBehaviour {
    //This script controls spawning new blocks.
    //TODO: no fucking world space coordinates
    public Block[,] grid;

    public int gridSizeX = 5;
    public int gridSizeY = 20;

    Block heldBlock;

    public int topRowOnScreen = 8;

    public GameObject[] blockList;
    public float fallSpeed = 2;
    public float bottom;

    // Use this for initialization
    void Start () {
        grid = new Block[gridSizeX,gridSizeY];
    }
    
    // Update is called once per frame
    void Update () {
        if (!heldBlock)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnNewBlock();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.A) && heldBlock.transform.position.x > 0)
            {
                heldBlock.MoveBlock(Vector2.left);
            }
            //TODO: check that right bounds of block are not off grid
            if (Input.GetKeyDown(KeyCode.D) && heldBlock.transform.position.x < 4)
            {
                heldBlock.MoveBlock(Vector2.right);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                heldBlock.Drop();
            }

            //TODO: Bad OOP
            if (heldBlock.falling)
            {
                heldBlock.transform.position += (Vector3.down * fallSpeed);


                if (heldBlock.transform.position.y < bottom)
                {
                    heldBlock.falling = false;
                    heldBlock.transform.position = new Vector3(heldBlock.transform.position.x, bottom, heldBlock.transform.position.z);

                    heldBlock.SetGridPos(new Vector2(heldBlock.transform.position.x,heldBlock.transform.position.y));
                    heldBlock.UpdateNeighbors();

                    heldBlock = null;
                }    
            }
        }
	}
    
    //TODO: some of this feels like bad OOP
    void SpawnNewBlock()
    {
        //TODO: some way of choosing different blocks
        GameObject newBlock = Instantiate(blockList[0]);

        //TODO: better block constructor
        newBlock.transform.parent = transform;
        heldBlock = newBlock.GetComponent<Block>();
        heldBlock.SiteManagerRef = this;

        heldBlock.gridPositionOfOrigin = new Vector2(0, gridSizeY - 1);
        heldBlock.MoveBlock(Vector2.zero);

        
    }
}
