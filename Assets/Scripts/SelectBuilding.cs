using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBuilding : MonoBehaviour {

	public Camera MainCamera;
	private GameObject Target;
	private GameObject Target_1;
	public static bool LookingAtBuilding;
	private bool Counting = false;
	private bool Selecting = false;
	public float SelectZoom;
	public float NoSelectZoom;
	private float counter = 0;
	public float SelectCount;
	public GameObject OuterRing;
	public float SelectSize;
	public float UnSelectSize;
	public GameObject Confirm;
	private bool ConfirmingDemolish = false;
	public float ConfirmSize;
	public Image AccentRing;
	public Color AccentRing_noselect;
	public Color AccentRing_demolish;

	// Use this for initialization
	void Start () {
		LookingAtBuilding = false;
		OuterRing.transform.localScale = Vector3.one * UnSelectSize;
		Confirm.transform.localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Selecting == false) {
		Ray ray = MainCamera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 20)) {
				//print ("I am hitting" + hit.collider.name);
				//print ("I am hitting" + hit.transform.parent.name);
				//print ("I am hitting" + hit.transform.root.name);
				Target = hit.transform.parent.gameObject;
				if (Input.GetMouseButtonDown (0)) {
					Counting = true;
				}
			}
		}

		if (Counting == true) 
		{
			counter += Time.deltaTime;
			if (counter > SelectCount) 
			{
				Selecting = true;
			}
		}
		if (Selecting == true) {
			this.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			LookingAtBuilding = true;
			MainCamera.transform.position = Vector3.Lerp (MainCamera.transform.position, new Vector3 (Target.transform.position.x, Target.transform.position.y, MainCamera.transform.position.z), 0.1f);
			MainCamera.orthographicSize = Mathf.Lerp (MainCamera.orthographicSize, SelectZoom, 0.1f);
			OuterRing.transform.localScale = Vector3.Lerp (OuterRing.transform.localScale, Vector3.one * SelectSize, 0.1f);
			if (ConfirmingDemolish == true) {
				Confirm.transform.localScale = Vector3.Lerp (Confirm.transform.localScale, Vector3.one * ConfirmSize, 0.25f);
				AccentRing.color = Color.Lerp (AccentRing.color, AccentRing_demolish, 0.1f);
			} 
			else 
			{
				Confirm.transform.localScale = Vector3.Lerp (Confirm.transform.localScale, Vector3.one * 0, 0.25f);
				AccentRing.color = Color.Lerp (AccentRing.color, AccentRing_noselect, 0.1f);
			}
		} else {
			MainCamera.orthographicSize = Mathf.Lerp (MainCamera.orthographicSize, NoSelectZoom, 0.1f);
			OuterRing.transform.localScale = Vector3.Lerp (OuterRing.transform.localScale, Vector3.one * UnSelectSize, 0.25f);
			Confirm.transform.localScale = Vector3.Lerp (Confirm.transform.localScale, Vector3.one * 0, 0.25f);
			AccentRing.color = Color.Lerp (AccentRing.color, AccentRing_noselect, 0.1f);
			this.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}

		if (Input.GetMouseButtonUp (0) && Selecting == true || Input.GetMouseButtonUp (0) && Counting == true) 
		{
			Counting = false;
			Selecting = false;
			counter = 0;
			LookingAtBuilding = false;
		}
	}
	public void ConfirmDemolish_on ()
	{
		Debug.Log ("on");
		ConfirmingDemolish = true;
	}
	public void ConfirmDemolish_off ()
	{
		ConfirmingDemolish = false;
	}
}
