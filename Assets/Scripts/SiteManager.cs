using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum LevelMode { Fixed,Random,MagicBag};

public class SiteManager : MonoBehaviour {
    //This script controls spawning and moving blocks.
	public static string SwipedDirection;
    CameraController camControllerRef;

    private int gridSizeX = 12;
    public int gridSizeY = 30;

    /// <summary>
    /// The actual height of the array being used.
    /// </summary>
    [HideInInspector]
    public int maxHeight = 20;

    public SiteData currentSite;

    //TODO: These might go well on SiteData
    public LevelMode modeSelect;
    public GameObject[] blockList;

    public int normalTopBlock = 0;
    public int shadowTopBlock = 0;

    [HideInInspector]
    public Block heldBlock;

    //TODO: move to color manager
    public Color ghostColor;
    public Color invalidMoveColor;

    public bool inShadow = false;

    void Awake()
    {
        camControllerRef = FindObjectOfType<CameraController>();

        currentSite = GetComponent<SiteData>();
        currentSite.grid = new Block[gridSizeX, gridSizeY];

        SwipedDirection = "null";
    }

    // Use this for initialization
    void Start () {

    }
    
    // Update is called once per frame
    void Update () {

        if (!heldBlock)
        {
            //TODO: possibly a delay or small animation on spawning a new block?
            
            SpawnNewBlock();
            inShadow = false;
            camControllerRef.ChangeCamPosition_leftright(1);
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
        GameObject newBlock = Instantiate(blockList[newBlockIndex],transform);
        heldBlock = newBlock.GetComponent<Block>();
        
        Vector2 newBlockPos = new Vector2(2, maxHeight - 1);
        heldBlock.SetGridPos(newBlockPos,false);   
    }

    public void ToggleShadow()
    {
        camControllerRef.ChangeCamPosition_leftright();
        if(!inShadow)
        {
            inShadow = true;
            if(heldBlock)
            {
                heldBlock.MoveBlock(new Vector2(7,0));
            }
        }
        else
        {
            inShadow = false;
            if (heldBlock)
            {
                heldBlock.MoveBlock(new Vector2(-7, 0));
            }
        }
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
