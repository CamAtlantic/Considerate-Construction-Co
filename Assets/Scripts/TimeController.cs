using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	public static int CurrentEnviroment;
	public Messages _Messages;
	private bool DuringDay = false;

	private Vector3 temp;
	private float currentTime;

	public float DayDuration_s;
	private float DayDuration_counting = 0;
	private int DayNumber = 0;
	public GameObject DottedCircle;
	public GameObject SunCenter_;
	public GameObject SunSymbol;
	public float DaySpeed;
	public static string TimeState;
	private Quaternion SunStartPosition;
	public GameObject time_Dawn;
	public GameObject time_Noon;
	public GameObject time_Dusk;
	public GameObject time_Twilight;

	// Use this for initialization
	void Start () {
		
		SunStartPosition = SunCenter_.transform.rotation;

		//deciding how to trigger
		_Messages.Message_1_on ();
		TimeState = "Twilight";
		CurrentEnviroment = 0;

	}
	
    //TODO: these movements need to use delta time.
	// Update is called once per frame
	void Update () {
		//sun circle segments
		SunCenter_.transform.eulerAngles = temp;
		SunSymbol.transform.Rotate (Vector3.back * 0.25f);
		if (DuringDay == true) {
			DottedCircle.transform.Rotate (Vector3.back * 0.25f);
			DayDuration_counting += Time.deltaTime;
				
			//first third - angle is creater than -60
			if (180 * ((DayDuration_counting - currentTime) / DayDuration_s) < (180 / 3) * 1) {
				//Debug.Log ("Dawn");
				TimeState = "Dawn";
				CurrentEnviroment = 1;
				temp = new Vector3 (0, 0, -(180 * ((DayDuration_counting - currentTime) / DayDuration_s)));
			}
			//second third - angle is creater than -120
			else if (180 * ((DayDuration_counting - currentTime) / DayDuration_s) < (180 / 3) * 2) {
				//Debug.Log ("Noon");
				TimeState = "Noon";
				CurrentEnviroment = 2;
				temp = new Vector3 (0, 0, -(180 * ((DayDuration_counting - currentTime) / DayDuration_s)));
			}
			//third third - angle is creater than -180
			else if (180 * ((DayDuration_counting - currentTime) / DayDuration_s) < (180 / 3) * 3) {
				//Debug.Log ("Dusk");
				TimeState = "Dusk";
				CurrentEnviroment = 3;
				temp = new Vector3 (0, 0, -(180 * ((DayDuration_counting - currentTime) / DayDuration_s)));
			} else {
				//Debug.Log ("Twilight");
				TimeState = "Twilight";
				CurrentEnviroment = 0;
				temp = new Vector3 (0, 0, -(180));
				DuringDay = false;
			}
		} 
		else if (DuringDay == false) 
		{
			//temp = new Vector3 (0, 0, 0);
			_Messages.Message_1_on ();
		}
	}

	public void StartNewDay ()
	{
		DayDuration_counting = 0;
		currentTime = Time.deltaTime;
		DuringDay = true;
		DayNumber++;
	}
}