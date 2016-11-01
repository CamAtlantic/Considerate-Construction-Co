using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LevelHeightBGManager : MonoBehaviour {

	public GameObject[] Level;
	public float[] LevelHeight;
	public float StartingHeight;
	public GameObject HeightLimit_0;
	public GameObject HeightLimit_1;
	public GameObject HeightLimit_2;
	public GameObject HeightLimit_3;
	public GameObject HeightLimit_4;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		HeightLimit_0.transform.position = new Vector3 (2, LevelHeight[0] + 5, 0);
		Level [0].transform.localScale = new Vector3 (20, LevelHeight[0], 20);
		Level [0].transform.position = new Vector3 (2, LevelHeight[0]/2 + StartingHeight, 50);
		HeightLimit_1.transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1]+ 5, 0);
		Level [1].transform.localScale = new Vector3 (20, LevelHeight[1], 20);
		Level [1].transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1]/2 + StartingHeight, 50);
		HeightLimit_2.transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1] + LevelHeight[2]+ 5, 0);
		Level [2].transform.localScale = new Vector3 (20, LevelHeight[2], 20);
		Level [2].transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1] + LevelHeight[2]/2 + StartingHeight, 50);
		HeightLimit_3.transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1] + LevelHeight[2] + LevelHeight[3]+ 5, 0);
		Level [3].transform.localScale = new Vector3 (20, LevelHeight[3], 20);
		Level [3].transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1] + LevelHeight[2] + LevelHeight[3]/2 + StartingHeight, 50);
		HeightLimit_4.transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1] + LevelHeight[2] + LevelHeight[3] + LevelHeight[4]+ 5, 0);
		Level [4].transform.localScale = new Vector3 (20, LevelHeight[4], 20);
		Level [4].transform.position = new Vector3 (2, LevelHeight[0] + LevelHeight[1] + LevelHeight[2] + LevelHeight[3] + LevelHeight[4]/2 + StartingHeight, 50);
	}
}
