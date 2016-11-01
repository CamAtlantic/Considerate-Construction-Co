using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_iconScript : MonoBehaviour {

	public GameObject MainCamera_start;
	public GameObject MainCamera_end;

	public GameObject AllIcons;
	public GameObject Icon_Center;
	public GameObject Icon_Ring;
	public GameObject Icon_Outer;
	public GameObject IconCenter_Destination;
	public GameObject ParticleEffect;

	private Animator a;
	public Animator b;

	private float count;
	public float ResetCount;
	public AnimationCurve TweenCurve;
	public float TestSpeed_rotate;

	private bool SwipedFromLoad = false;

	public float ButtonSize;
	public float CurveSpeed;
	private float currentCurveSize = 0f;
	private float currentCurveAngle = -Mathf.PI/2f;

	public static string SwipeDirection;

	// Use this for initialization
	void Start () {
		SwipeDirection = "null";

		a = GetComponent<Animator> ();
		ParticleEffect.SetActive (false);
		
	}

	// Update is called once per frame
	void Update () 
		{
		if (a.GetCurrentAnimatorStateInfo(0).IsName("icon_4_waiting")) 
		{
			b.SetBool ("SwipeDown", true);
			ParticleEffect.SetActive (true);
		
		if (SwipeDirection == "down") 
			{
				SwipedFromLoad = true;
			}
		}
		if (SwipedFromLoad == true) {
			Icon_Center.transform.position = Vector3.Lerp (Icon_Center.transform.position, IconCenter_Destination.transform.position, 0.01f);
			Icon_Center.transform.localScale = Vector3.Lerp (Icon_Center.transform.localScale, IconCenter_Destination.transform.localScale, 0.05f);
			MainCamera_start.transform.position = Vector3.Lerp (MainCamera_start.transform.position, MainCamera_end.transform.position, 0.01f);
			a.enabled = false;
		}

		//loading pulse

		//finish sequence
		/*AllIcons.transform.Rotate (Vector3.back * 3);
		//AllIcons.transform.rotation = CurveRotation (AllIcons.transform.rotation, AllIcons_Rotated.transform.rotation, TweenCurve);
				currentCurveAngle += Time.deltaTime * CurveSpeed;
				if (currentCurveAngle >= 2 * Mathf.PI) {
					currentCurveAngle -= 2 * Mathf.PI;
				}
				currentCurveSize = Mathf.Sin (currentCurveAngle);
			Icon_Ring.transform.localScale = Vector3.one * (ButtonSize * (1 + (0.05f * currentCurveSize)));*/
		} 
		//else 
		//{
		//	Notice_button.transform.localScale = Vector3.Lerp (Notice_button.transform.localScale, Vector3.one * 0, 0.1f);
		//}
		Quaternion CurveRotation(Quaternion pos1, Quaternion pos2, AnimationCurve ac)
		{
			return Quaternion.Lerp (pos1, pos2, ac.Evaluate (TestSpeed_rotate));
		}
	}


