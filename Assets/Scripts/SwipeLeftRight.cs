using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLeftRight : MonoBehaviour 
	{
		public GameObject MouseCurrentLocation;
		public GameObject MouseStartLocation;
		private float DistanceBetween;
		public float IntervalCount;

		void Update() 
		{
		IntervalCount = Screen.width / 6;

			if (Input.GetMouseButtonDown (0)) 
			{
				MouseStartLocation.transform.position = Input.mousePosition;
			}
			if (Input.GetMouseButton (0)) 
			{
				MouseCurrentLocation.transform.position = Input.mousePosition;
			}
			if (Input.GetMouseButtonUp (0)) 
			{
				MouseStartLocation.transform.position = MouseCurrentLocation.transform.position;
			}

		DistanceBetween = (MouseStartLocation.transform.position.x - MouseCurrentLocation.transform.position.x);
		//Debug.Log (DistanceBetween);

			if (DistanceBetween < 0) 
			{
			if (DistanceBetween < -(IntervalCount)) 
				{
					Debug.Log ("right");
					SiteManager.SwipeRight ();
					MouseStartLocation.transform.position = MouseCurrentLocation.transform.position;
				}
			} 
			else if (DistanceBetween > 0)
			{
				if (DistanceBetween > IntervalCount) 
				{
					Debug.Log ("left");
					SiteManager.SwipeLeft ();
					MouseStartLocation.transform.position = MouseCurrentLocation.transform.position;
				}
			}
		}
	}
