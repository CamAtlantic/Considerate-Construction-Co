using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	public static int CurrentEnviroment;
	public Messages _Messages;
	private bool DuringDay = false;

	public float DaySegmentDuration_s;
	private float DaySegmentDuration_counting = 0;
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

		time_Twilight.transform.rotation = SunStartPosition *= Quaternion.AngleAxis (0, Vector3.back);
		time_Dawn.transform.rotation = SunStartPosition *= Quaternion.AngleAxis (90, Vector3.back);
		time_Noon.transform.rotation = SunStartPosition *= Quaternion.AngleAxis (90, Vector3.back);
		time_Dusk.transform.rotation = SunStartPosition *= Quaternion.AngleAxis (90, Vector3.back);
	}
	
	// Update is called once per frame
	void Update () {
		//sun circle segments
		if (DuringDay == true) 
		{
			DottedCircle.transform.Rotate (Vector3.back * 0.25f);
			SunSymbol.transform.Rotate (Vector3.back * 0.25f);
			DaySegmentDuration_counting += Time.deltaTime;
			if (DaySegmentDuration_counting > DaySegmentDuration_s) 
			{
				DaySegmentDuration_counting = 0;
				if (TimeState == "Twilight") 
				{
					TimeState = "Dawn";
					CurrentEnviroment = 1;
				} 
				else if (TimeState == "Dawn") 
				{
					TimeState = "Noon";
					CurrentEnviroment = 2;
				} 
				else if (TimeState == "Noon") 
				{
					TimeState = "Dusk";
					CurrentEnviroment = 3;
				} 
				else if (TimeState == "Dusk") 
				{
					CurrentEnviroment = 0;
					TimeState = "Twilight";
					//_Messages.Message_1_on ();
					DuringDay = false;
				}
			}
		}
		//movement patterns
		if (TimeState == "Twilight") {
			SunCenter_.transform.rotation = Quaternion.Lerp (SunCenter_.transform.rotation, time_Twilight.transform.rotation, DaySpeed * Time.deltaTime);
		} else if (TimeState == "Dawn") {
			SunCenter_.transform.rotation = Quaternion.Lerp (SunCenter_.transform.rotation, time_Dawn.transform.rotation, DaySpeed * Time.deltaTime);
		} else if (TimeState == "Noon") {
			SunCenter_.transform.rotation = Quaternion.Lerp (SunCenter_.transform.rotation, time_Noon.transform.rotation, DaySpeed * Time.deltaTime);
		} else if (TimeState == "Dusk") {
			SunCenter_.transform.rotation = Quaternion.Lerp (SunCenter_.transform.rotation, time_Dusk.transform.rotation, DaySpeed * Time.deltaTime);
		}
	}

	public void StartNewDay ()
	{
		DaySegmentDuration_counting = DaySegmentDuration_s;
		DuringDay = true;
		DayNumber++;
	}
}