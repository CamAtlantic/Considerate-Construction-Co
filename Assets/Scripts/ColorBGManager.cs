using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColorBGManager : MonoBehaviour {

	public int TotalHeightLevels = 0;
	public int OrderInHeight = 0;
	public Material[] Materials;
	public Color[] Tops;
	public Color[] Bots;

	void Start () 
	{
		
	}

	void Update () 
	{
		if (Materials.Length != TotalHeightLevels) 
		{
			Materials = new Material[TotalHeightLevels];
			Tops = new Color[TotalHeightLevels];
			Bots = new Color[TotalHeightLevels];
		}


		for (int i = 0; i < TotalHeightLevels; i++) 
		{
			Materials [i].SetColor ("_TopColor", Tops [i]);
			Materials [i].SetColor ("_BottomColor", Bots [i]);
		}
	}
}
