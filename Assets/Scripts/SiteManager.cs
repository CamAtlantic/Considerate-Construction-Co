using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;

public class SiteManager : MonoBehaviour {
    //This script controls spawning new blocks.

	public static string SwipedDirection;

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

		SwipedDirection = "null";
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
			//jai's new swipe-
			if (SwipedDirection == "left" && heldBlock.transform.position.x > 0) {
				heldBlock.transform.position += Vector3.left;
				SwipedDirection = "null";
			}

			if (SwipedDirection == "right" && heldBlock.transform.position.x < 4) {
				heldBlock.transform.position += Vector3.right;
				SwipedDirection = "null";
			}

			if (SwipedDirection == "down") {
				DropHeldBlock();
				SwipedDirection = "null";
			}
			//jai's new swipe

            //TODO: Bad OOP
            if (heldBlock.falling)
            {
                heldBlock.transform.position += (Vector3.down * fallSpeed);


                if (heldBlock.transform.position.y < bottom)
                {
                    heldBlock.falling = false;
                    heldBlock.transform.position = new Vector3(heldBlock.transform.position.x, bottom, heldBlock.transform.position.z);

                    heldBlock.SetGridPos((int)heldBlock.transform.position.x, (int)heldBlock.transform.position.y);
                    heldBlock.UpdateNeighbors();

                    heldBlock = null;
                }    
            }
        }
	}
    //TODO: both of these maybe should be on Block script
    void DropHeldBlock()
    {
        heldBlock.falling = true;
//        bottom = CheckColumnHeight((int)heldBlock.transform.position.x, (int)heldBlock.transform.position.y);
    }
/*
    float CheckColumnHeight(int col, int startHeight)
    {
        for (int i = startHeight; i >= 0; i--)
        {
            if (grid[col, i] == null)
                continue;
            else
            {
                return grid[col, i].transform.position.y + 1;
            }
        }
        return 0f;
    }
    */
    //TODO: some of this feels like bad OOP
    void SpawnNewBlock()
    {
        //TODO: some way of choosing different blocks
        GameObject newBlock = Instantiate(blockList[0]);
        newBlock.transform.parent = transform;
        //TODO: blocks spawn higher when, for example, there is already a block on 8th row
        newBlock.transform.position = new Vector3(2, 8f, 0);
        heldBlock = newBlock.GetComponent<Block>();
        heldBlock.SiteManagerRef = this;
    }

	public static void SwipeLeft() {
		SwipedDirection = "left";
	}
	public static void SwipeRight() {
		SwipedDirection = "right";
	}
	public static void SwipeUp() {
		SwipedDirection = "up";
	}
	public static void SwipeDown() {
		SwipedDirection = "down";
	}
}
