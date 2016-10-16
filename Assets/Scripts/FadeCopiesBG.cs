using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCopiesBG : MonoBehaviour {

	public Material fadeMaterial;
	public Material targetMaterial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		fadeMaterial.SetColor ("_Color",  targetMaterial.GetColor ("_ColorOne"));
		
	}
}
