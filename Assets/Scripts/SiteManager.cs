using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;

public enum LevelMode { Fixed,Random,MagicBag};

public class SiteManager : MonoBehaviour
{
    //This script controls spawning and moving blocks.
    
    public bool TutorialMode = false;
    [Space(10)]
    public static string SwipedDirection;

    CameraController camControllerRef;

    public GameObject buildingSitePrefab;
    [HideInInspector]
    public SiteData siteDataRef;

    private int gridSizeX = 12;
    public int gridSizeY = 30;

    /// <summary>
    /// The actual height of the array being used.
    /// </summary>
    [HideInInspector]
    public int maxHeight = 30;

    //TODO: These might go well on SiteData
    public LevelMode modeSelect;
    public GameObject[] blockList;

    [HideInInspector]
    public Block heldBlock;

    public bool inShadow = false;
    void Awake()
    {
        camControllerRef = FindObjectOfType<CameraController>();

        GameObject newSite = Instantiate(buildingSitePrefab);
        siteDataRef = newSite.GetComponent<SiteData>();
        siteDataRef.grid = new Block[gridSizeX, gridSizeY];

        SwipedDirection = "null";
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
                Input.GetKeyDown(KeyCode.LeftArrow))
            {
                heldBlock.MoveBlock(Vector2.left);
				//LeanTouchEvents.OnDrag ();
                SwipedDirection = "null";
            }

            if (SwipedDirection == "right" ||
                Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.RightArrow))
            {
                heldBlock.MoveBlock(Vector2.right);
                SwipedDirection = "null";
            }

            if (SwipedDirection == "down" ||
                Input.GetKeyDown(KeyCode.Space))
            {
                if (heldBlock.CheckGhostPos())
                {
                    heldBlock.Drop();
                    SwipedDirection = "null";
                }
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(heldBlock.ghost);
                Destroy(heldBlock.gameObject);
                heldBlock = null;
                SpawnNewBlock();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                heldBlock.FlipHorizontal();
                heldBlock.CheckGhostPos();
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
            if (fixedModeIndex == blockList.Length)
            {
                //here is where the level can end or we can reset or something
                fixedModeIndex = 0;
            }
        }
        GameObject newBlock = Instantiate(blockList[newBlockIndex], siteDataRef.transform);
        heldBlock = newBlock.GetComponent<Block>();

        Vector2 newBlockPos = new Vector2(2, siteDataRef.normalTopBlock + 10);
        heldBlock.SetGridPos(newBlockPos, false);
    }

    public void ToggleShadow()
    {
        camControllerRef.ChangeCamPosition_leftright();
        if (!inShadow)
        {
            inShadow = true;
            if (heldBlock)
            {
                heldBlock.MoveBlock(new Vector2(7, 0));
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
    public static void SwipeLeft()
    {
        SwipedDirection = "left";
    }
    public static void SwipeRight()
    {
        SwipedDirection = "right";
    }
    public static void SwipeUp()
    {
        SwipedDirection = "up";
    }
    public static void SwipeDown()
    {
        SwipedDirection = "down";
    }
    #endregion
}
