using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;


public class SiteManager : MonoBehaviour
{
    //This script controls spawning and moving blocks.
    
    TutorialMode tutorialScript;

    public bool gamePaused = false;

    public static string SwipedDirection;
    public bool tapped;

    CameraController camControllerRef;

    public GameObject buildingSitePrefab;
    [HideInInspector]
    public SiteData siteDataRef;

    private int gridSizeX = 12;
    public int gridSizeY = 30;

    /// <summary>
    /// The actual height of the array being used.
    /// </summary>
    public int maxHeight = 20;
    GameObject heightLimitUI;

    [HideInInspector]
    public Block heldBlock;

    public bool inShadow = false;

    public float newBlockDelay = 0.1f;
    private float newBlockTimer = 0;

    void Awake()
    {
        camControllerRef = FindObjectOfType<CameraController>();
        heightLimitUI = GameObject.FindGameObjectWithTag("HeightLimitUI");
        if (!heightLimitUI)
            Debug.LogError("Can't find height limit UI thingy!!");
 
        //make pillar ready for tutorial
        //TODO: something something siteData
        
        SwipedDirection = "null";
    }

    // Use this for initialization
    void Start()
    {
        if (FindObjectOfType<TutorialMode>())
        {
            tutorialScript = FindObjectOfType<TutorialMode>();
            siteDataRef = FindObjectOfType<SiteData>();
            tutorialScript.SetUpPillar(gridSizeX, gridSizeY);
        }
        else
        {
            //normal operations
            GameObject newSite = Instantiate(buildingSitePrefab);
            siteDataRef = newSite.GetComponent<SiteData>();
            siteDataRef.grid = new Block[gridSizeX, gridSizeY];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!heldBlock)
        {
            newBlockTimer += Time.deltaTime;
            if (newBlockTimer > newBlockDelay)
            {
                newBlockTimer = 0;
                SpawnNewBlock();
                inShadow = false;
                camControllerRef.ChangeCamPosition_leftright(1);
            }
        }
        else if(!gamePaused && SelectBuilding.Selecting == false)
        {
            
            GetInput();
        }
    }


    void GetInput()
    {
        if (SwipedDirection == "left" ||
               Input.GetKeyDown(KeyCode.A) ||
               Input.GetKeyDown(KeyCode.LeftArrow))
        {
            heldBlock.MoveBlock(Vector2.left);
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
        if (Input.GetKeyDown(KeyCode.Alpha1) || tapped)
        {
            heldBlock.FlipHorizontal();
            tapped = false;
        }
    }
    //TODO: this function should be on siteData probably
    int fixedModeIndex = 0;
    void SpawnNewBlock()
    {
        siteDataRef.currentBlock++;

        int newBlockIndex = 0;

        if (siteDataRef.modeSelect == LevelMode.Random)
            newBlockIndex = Random.Range(0, siteDataRef.blockList.Length);
        else if (siteDataRef.modeSelect == LevelMode.Fixed)
        {
            newBlockIndex = fixedModeIndex;
            fixedModeIndex++;
            if (fixedModeIndex == siteDataRef.blockList.Length)
            {
                //here is where the level can end or we can reset or something
                fixedModeIndex = 0;
            }
        }
        GameObject newBlock = Instantiate(siteDataRef.blockList.list[newBlockIndex], siteDataRef.transform);
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
    protected virtual void OnEnable()
    {
        // Hook into the events we need
        LeanTouch.OnFingerTap += OnFingerTap;
    }
    protected virtual void OnDisable()
    {
        // Unhook the events
        LeanTouch.OnFingerTap -= OnFingerTap;
    }
    private void OnFingerTap(LeanFinger finger)
    {
        tapped = true;
    }
    #endregion
}
