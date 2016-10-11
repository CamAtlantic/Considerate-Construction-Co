using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SiteManager : MonoBehaviour {
    //This script controls spawning new blocks.
    //TODO: no fucking world space coordinates
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
[HideInInspector]
    public Block heldBlock;
    //GhostInfo ghostOfHeldBlock;

    public int topRowOnScreen = 8;

    public GameObject[] blockList;
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                heldBlock.MoveBlock(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                heldBlock.MoveBlock(Vector2.right);
            }

            if (Input.GetKeyDown(KeyCode.Space) && heldBlock.CheckGhostPos())
            {
                heldBlock.Drop();
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
}
