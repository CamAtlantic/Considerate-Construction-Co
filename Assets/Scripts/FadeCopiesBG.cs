using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCopiesBG : MonoBehaviour {

	public Material fadeMaterial;
	public Material[] targetMaterial;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//fadeMaterial.SetColor ("_Color",  targetMaterial[ ColorManager.ActiveColorScheme ].GetColor ("_BottomColor"));
		//Debug.Log (targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").r);
		//fadeMaterial.color = new Color (
		//fadeMaterial.color.r = targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").r;
		//fadeMaterial.color.g = targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").g;
		//fadeMaterial.color.b = targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").b;
		
	}
}
