using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	public float DayDuration_s;
	private float DayDuration_counting = 0;
	private int DayNumber = 0;

	public GameObject DottedCircle;
	public GameObject SunSymbol;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		DayDuration_counting += Time.deltaTime;
		if (DayDuration_counting > DayDuration_s) 
		{
			DayDuration_counting = 0;
			DayNumber++;
			Debug.Log ("Day " + DayNumber);
		}

		DottedCircle.transform.Rotate (Vector3.back); 
	}
}
