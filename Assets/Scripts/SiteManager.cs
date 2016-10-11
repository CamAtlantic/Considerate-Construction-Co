using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;

public class SiteManager : MonoBehaviour {
    //This script controls spawning new blocks.
    //TODO: standardize worldSpace vs local.
	public static string SwipedDirection;
    
    public Block[,] grid;

    public int gridSizeX = 5;
    /// <summary>
    /// The size of the array. Larger than the maxHeight to avoid Out of Range fuckery.
    /// </summary>
    public int gridSizeY = 30;
    /// <summary>
    /// The actual size of the array being used.
    /// </summary>
    public int maxHeight = 20;

    public int topRowOnScreen = 8;

    public GameObject[] blockList;

    [HideInInspector]
    public Block heldBlock;

    // Use this for initialization
    void Start () {
        grid = new Block[gridSizeX,gridSizeY];

		SwipedDirection = "null";
    }
    
    // Update is called once per frame
    void Update () {
		
        if (!heldBlock)
        {
            //TODO: not spawn blocks on pressing space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnNewBlock();
            }
        }
        else
        {
            //Does this work with keyboard controls?
            if (SwipedDirection == "left" && heldBlock.transform.position.x > 0) {
                heldBlock.MoveBlock(Vector2.left);
                SwipedDirection = "null";
			}

			if (SwipedDirection == "right" && heldBlock.transform.position.x < 4) {
                heldBlock.MoveBlock(Vector2.right);
                SwipedDirection = "null";
			}

			if (SwipedDirection == "down" && heldBlock.CheckGhostPos()) {
                heldBlock.Drop();
                SwipedDirection = "null";
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

        Vector2 newBlockPos = new Vector2(2, maxHeight - 1);
        heldBlock.SetGridPos(newBlockPos,false);
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
