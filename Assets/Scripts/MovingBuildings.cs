using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBuildings : MonoBehaviour {

	public GameObject Obj_real;
	private GameObject Obj_fade;

	private bool Clicked = false;

	// Use this for initialization
	void Start () {

		Obj_fade = Instantiate (Obj_real);
		Obj_real.transform.position = Obj_real.transform.position + Vector3.up * 50;

		//Obj_fade.GetComponentInChildren <SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			ClickedFadedModel ();
		}

		if (Clicked == true) {
			Obj_real.transform.position = Vector3.Lerp (Obj_real.transform.position, Obj_fade.transform.position, 0.1f);
		}
		
	}

	void ClickedFadedModel () 
	{
		Clicked = true;
	}
}
