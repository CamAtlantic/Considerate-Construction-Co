using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FadeCopiesBG : MonoBehaviour {

	public Material fadeMaterial;
	public Material[] targetMaterial;
	public bool TopColor = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (TopColor == true) {
			fadeMaterial.color = new Color (targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_TopColor").r, targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_TopColor").g, targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_TopColor").b, 1f);
		}
		if (TopColor == false) {
			fadeMaterial.color = new Color (targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").r, targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").g, targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").b, 1f);
		}

	}
}
