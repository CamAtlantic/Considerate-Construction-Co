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
		fadeMaterial.color = new Color (targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").r, targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").g, targetMaterial [ColorManager.ActiveColorScheme].GetColor ("_BottomColor").b, 1f);
		
	}
}
