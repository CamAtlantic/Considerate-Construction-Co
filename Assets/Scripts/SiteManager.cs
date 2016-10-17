using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum LevelMode { Fixed,Random,MagicBag};

public class SiteManager : MonoBehaviour {
    //This script controls spawning and moving blocks.
    //TODO: standardize worldSpace vs local.
	public static string SwipedDirection;
    
    public Block[,] grid;

    public int gridSizeX = 5;
    /// <summary>
    /// The size of the array. Larger than the maxHeight to avoid Out of Range fuckery.
    /// </summary>
    [HideInInspector]
    public int gridSizeY = 30;
    /// <summary>
    /// The actual size of the array being used.
    /// </summary>
    [HideInInspector]
    public int maxHeight = 20;

    public int topBlockHeight = 0;
	public static int topBlockHeight_static = 0;

    public LevelMode modeSelect;

    public GameObject[] blockList;

    [HideInInspector]
    public Block heldBlock;

    //I feel like these should be on another, global script. Maybe SiteManager? or Jai's color manager thing.
    public Color ghostColor;
    public Color invalidMoveColor;

    // Use this for initialization
    void Start () {
        grid = new Block[gridSizeX,gridSizeY];

		SwipedDirection = "null";
    }
    
    // Update is called once per frame
    void Update () {
		
		topBlockHeight_static = topBlockHeight;

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
            if (SwipedDirection == "left" ||
                Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.LeftArrow)) {
                heldBlock.MoveBlock(Vector2.left);
                SwipedDirection = "null";
			}

			if (SwipedDirection == "right" ||
                Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.RightArrow)) {
                heldBlock.MoveBlock(Vector2.right);
                SwipedDirection = "null";
			}

			if (SwipedDirection == "down" ||
                Input.GetKeyDown(KeyCode.Space)){
                if (heldBlock.CheckGhostPos())
                {
                    heldBlock.Drop();
                    SwipedDirection = "null";
                }
			}

            if(Input.GetKeyDown(KeyCode.X))
            {
                Destroy(heldBlock.ghost);
                Destroy(heldBlock.gameObject);
                heldBlock = null;
                SpawnNewBlock();
            }
        }
    }

    int fixedModeIndex = 0;
    //TODO: some of this feels like bad OOP
    void SpawnNewBlock()
    {
        //TODO: some way of choosing different blocks
        int newBlockIndex = 0;

        if (modeSelect == LevelMode.Random)
            newBlockIndex = Random.Range(0, blockList.Length);
        else if (modeSelect == LevelMode.Fixed)
        {
            newBlockIndex = fixedModeIndex;
            fixedModeIndex++;
            if(fixedModeIndex == blockList.Length)
            {
                //here is where the level can end or we can reset or something
                fixedModeIndex = 0;
            }
        }
        GameObject newBlock = Instantiate(blockList[newBlockIndex]);

        //TODO: better block constructor
        newBlock.transform.parent = transform;
        heldBlock = newBlock.GetComponent<Block>();
        heldBlock.SiteManagerRef = this;

        Vector2 newBlockPos = new Vector2(2, maxHeight - 1);
        heldBlock.SetGridPos(newBlockPos,false);
        
    }
    #region swipes
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
    #endregion
}
