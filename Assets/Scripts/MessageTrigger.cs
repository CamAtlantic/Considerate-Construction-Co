using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTrigger : MonoBehaviour {

	public GameObject Message_base;
	public GameObject Message_1;
	public GameObject Message_2;

	public static bool Message_on_1 = false;
	public static bool Message_on_2 = false;

	// Use this for initialization
	void Start () {
		Message_1.gameObject.SetActive (false);
		Message_2.gameObject.SetActive (false);
		Message_1.transform.localScale = Vector3.one * 6;
		Message_2.transform.localScale = Vector3.one * 6;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("a")) {
			Message_1_on ();
		}
		if (Input.GetKeyDown ("b")) {
			Message_2_on ();
		}

		if (Message_on_1 == true) 
		{
			Message_1.gameObject.SetActive (true);
			Message_base.SetActive (true);
			Message_1.transform.localScale = Vector3.Lerp (Message_1.transform.localScale, Vector3.one * 10, 0.1f);
		}
		else if (Message_on_2 == true) 
		{
			Message_2.gameObject.SetActive (true);
			Message_base.SetActive (true);
			Message_2.transform.localScale = Vector3.Lerp (Message_2.transform.localScale, Vector3.one * 10, 0.1f);
		}
		else if (Message_on_1 == false) 
		{
			Message_1.gameObject.SetActive (false);
			Message_base.SetActive (false);
			Message_1.transform.localScale = Vector3.Lerp (Message_1.transform.localScale, Vector3.one * 6, 0.1f);
		}
		else if (Message_on_2 == false) 
		{
			Message_2.gameObject.SetActive (false);
			Message_base.SetActive (false);
			Message_2.transform.localScale = Vector3.Lerp (Message_2.transform.localScale, Vector3.one * 6, 0.1f);
		}
		
	}

	public void Message_1_on ()
	{
		Message_1.gameObject.SetActive (true);
		Message_on_1 = true;

		Message_2.gameObject.SetActive (false);
		Message_on_2 = false;
	}

	public void Message_1_off ()
	{
		Message_on_1 = false;
		Message_1.gameObject.SetActive (false);
	}

	public void Message_2_on ()
	{
		Message_2.gameObject.SetActive (true);
		Message_on_2 = true;

		Message_on_1 = false;
		Message_1.gameObject.SetActive (false);
	}

	public void Message_2_off ()
	{
		Message_2.gameObject.SetActive (false);
		Message_on_2 = false;
	}
}
