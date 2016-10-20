using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    SiteManager siteManagerRef;
    public float cameraOffset;

    /// <summary>
    /// 1 = left; 2 = right
    /// </summary>
    private int CameraLocation_leftright = 1;
    /// <summary>
    /// -1 = backward; 0 = standard; 1 = forward
    /// </summary>
    private int CameraLocation_updown;

    private int leftXPos = 2;
    private int rightXPos = 9;
    public float lerpSpeed = 0.1f;

    public CameraMode mode = CameraMode.MoveWithBlock;

    void Awake()
    {
        siteManagerRef = FindObjectOfType<SiteManager>();
        CameraLocation_leftright = 1;

    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //== Vertical ==============================
		if (SelectBuilding.LookingAtBuilding == false) 
		{
			if (mode == CameraMode.MoveWithBlock && siteManagerRef.heldBlock) {
				LerpToHeight ((int)siteManagerRef.heldBlock.ghostOrigin.y);
			} else {
				if (siteManagerRef.inShadow)
					LerpToHeight (siteManagerRef.shadowTopBlock);
				else
					LerpToHeight (siteManagerRef.normalTopBlock);
			}
        
			//== Horizontal ==============================
			if (CameraLocation_leftright == 1) {
				transform.position = Vector3.Lerp (transform.position,
					new Vector3 (leftXPos, transform.position.y, transform.position.z), lerpSpeed);
			}
			if (CameraLocation_leftright == 2) {
				transform.position = Vector3.Lerp (transform.position,
					new Vector3 (rightXPos, transform.position.y, transform.position.z), lerpSpeed);
			}
		}
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
    public void ChangeCamPosition_leftright(int leftRight)
    {
        CameraLocation_leftright = leftRight;
    }
    
    void LerpToHeight(int height)
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, height + cameraOffset, transform.position.z), lerpSpeed);
    }

    public enum CameraMode {FixedToHeight,MoveWithBlock}
}
