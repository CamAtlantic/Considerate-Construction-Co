using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelMode { Fixed, Random, MagicBag };

public class SiteData : MonoBehaviour {

    public Block[,] grid = new Block[0,0];

    public int normalTopBlock = 0;
    public int shadowTopBlock = 0;

    public LevelMode modeSelect;
    public BlockList blockList;

    public int currentBlock;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
