using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuidlingControllerScript : MonoBehaviour {

	public float Depth;
	public int MyColorCode;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y, -(Depth/5 + 1));

		if (MyColorCode == 1) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_1;
		}
		if (MyColorCode == 2) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_2;
		}
		if (MyColorCode == 3) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_3;
		}
		if (MyColorCode == 4) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_4;
		}
		if (MyColorCode == 5) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_5;
		}
		if (MyColorCode == 6) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_6;
		}
		if (MyColorCode == 7) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_7;
		}
		if (MyColorCode == 8) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_8;
		}
		if (MyColorCode == 9) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_9;
		}
		if (MyColorCode == 10) {
			GetComponent <SpriteRenderer> ().color = ColorManager.Clr_10;
		}
	}
}
