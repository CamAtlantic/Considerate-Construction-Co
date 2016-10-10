using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject MainCamera;
	public GameObject Location_left;
	public GameObject Location_right;
	public GameObject Location_depth;
	public float DistanceBetweenPlots;
	//leftright 1 = left; 2 = right
	private int CameraLocation_leftright;
	//updown -1 = backward; 0 = standard; 1 = forward
	private int CameraLocation_updown;

	// Use this for initialization
	void Start () {
		
		CameraLocation_leftright = 1;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (CameraLocation_leftright == 1) {
			MainCamera.transform.position = Vector3.Lerp (MainCamera.transform.position, new Vector3 (Location_left.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z ), 0.1f);
		}
		if (CameraLocation_leftright == 2) {
			MainCamera.transform.position = Vector3.Lerp (MainCamera.transform.position, new Vector3 (Location_right.transform.position.x,MainCamera.transform.position.y,MainCamera.transform.position.z), 0.1f);
		}

		MainCamera.transform.position = Vector3.Lerp (MainCamera.transform.position, new Vector3 (MainCamera.transform.position.x,MainCamera.transform.position.y,Location_depth.transform.position.z), 0.1f);

	}
		
	public void ChangeCamPosition_leftright ()
	{
		if (CameraLocation_leftright == 1) {
			CameraLocation_leftright = 2;
		}
		else if (CameraLocation_leftright == 2) {
			CameraLocation_leftright = 1;
		}
	}

	public void ChangeCamPosition_forward ()
	{
		Location_depth.transform.position = MainCamera.transform.position + Vector3.back * DistanceBetweenPlots;
	}

	public void ChangeCamPosition_back ()
	{
		Location_depth.transform.position = MainCamera.transform.position + Vector3.forward * DistanceBetweenPlots;
	}
}
