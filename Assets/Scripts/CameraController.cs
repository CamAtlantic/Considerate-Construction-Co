using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//public GameObject MainCamera;
    public float cameraOffset;
    //public GameObject Location_left;
    //public GameObject Location_right;
    //public GameObject Location_depth;
    //public float DistanceBetweenPlots;

    //leftright 1 = left; 2 = right
    private int CameraLocation_leftright = 1;
	//updown -1 = backward; 0 = standard; 1 = forward
	private int CameraLocation_updown;

    public int leftXPos = 2;
    public int rightXPos = 10;
    public float lerpSpeed = 0.1f;

	// Use this for initialization
	void Start () {
        CameraLocation_leftright = 1;

    }
	
	// Update is called once per frame
	void Update () {
        
		transform.position = Vector3.Lerp (transform.position,
            new Vector3 (transform.position.x, SiteManager.topBlockHeight_static + cameraOffset, transform.position.z), lerpSpeed);

        
		if (CameraLocation_leftright == 1) {
			transform.position = Vector3.Lerp (transform.position,
                new Vector3 (leftXPos, transform.position.y, transform.position.z ), lerpSpeed);
		}
		if (CameraLocation_leftright == 2) {
			transform.position = Vector3.Lerp (transform.position,
                new Vector3 (rightXPos,transform.position.y,transform.position.z), lerpSpeed);
		}

		//MainCamera.transform.position = Vector3.Lerp (MainCamera.transform.position, new Vector3 (MainCamera.transform.position.x,MainCamera.transform.position.y,Location_depth.transform.position.z), 0.1f);
       
	}
	
	public void ChangeCamPosition_leftright ()
	{
        print(CameraLocation_leftright);

        if (CameraLocation_leftright == 1) {
			CameraLocation_leftright = 2;
		}
		else if (CameraLocation_leftright == 2) {
			CameraLocation_leftright = 1;
		}
	}
    /*
	public void ChangeCamPosition_forward ()
	{
		Location_depth.transform.position = MainCamera.transform.position + Vector3.back * DistanceBetweenPlots;
	}

	public void ChangeCamPosition_back ()
	{
		Location_depth.transform.position = MainCamera.transform.position + Vector3.forward * DistanceBetweenPlots;
	}
    */
}
