using UnityEngine;
using System.Collections;

public class BG_ColorLerp : MonoBehaviour
{

	public Material myMaterial;
	public Material[] Enviroments;
	int indexMaterial = 0;

	public float lerpColorSpeed;
	public float lerpFloatSpeed;
	Color TransitionColor;
	float TransitionFloat;

	public bool editMode;

	bool snapThisFloat;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		indexMaterial = TimeController.CurrentEnviroment;
		indexMaterial %= Enviroments.Length;

		if (editMode == true) {
			Debug.Log ("LerpEditMode = " + editMode);

			TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_YOffset"), Enviroments [indexMaterial].GetFloat ("_YOffset"), lerpFloatSpeed);
			myMaterial.SetFloat ("_YOffset", TransitionFloat);

			TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_YScale"), Enviroments [indexMaterial].GetFloat ("_YScale"), lerpFloatSpeed);
			myMaterial.SetFloat ("_YScale", TransitionFloat);

			TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_Emit"), Enviroments [indexMaterial].GetFloat ("_Emit"), lerpFloatSpeed);
			myMaterial.SetFloat ("_Emit", TransitionFloat);

			TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_VertOffset"), Enviroments [indexMaterial].GetFloat ("_VertOffset"), lerpFloatSpeed);
			myMaterial.SetFloat ("_VertOffset", TransitionFloat);

			TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_VertWobble"), Enviroments [indexMaterial].GetFloat ("_VertWobble"), lerpFloatSpeed);
			myMaterial.SetFloat ("_VertWobble", TransitionFloat);

			TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_VertWobbleSpeed"), Enviroments [indexMaterial].GetFloat ("_VertWobbleSpeed"), lerpFloatSpeed);
			myMaterial.SetFloat ("_VertWobbleSpeed", TransitionFloat);

			TransitionColor = Color.Lerp (myMaterial.GetColor ("_ColorTwo"), Enviroments [indexMaterial].GetColor ("_ColorTwo"), lerpColorSpeed);
			myMaterial.SetColor ("_ColorTwo", TransitionColor);

			TransitionColor = Color.Lerp (myMaterial.GetColor ("_ColorOne"), Enviroments [indexMaterial].GetColor ("_ColorOne"), lerpColorSpeed);
			myMaterial.SetColor ("_ColorOne", TransitionColor);

			TransitionColor = Color.Lerp (myMaterial.GetColor ("_ShadeColor"), Enviroments [indexMaterial].GetColor ("_ShadeColor"), lerpColorSpeed);
			myMaterial.SetColor ("_ShadeColor", TransitionColor);
		} else {
			if ((Mathf.Abs (myMaterial.GetColor ("_ColorTwo").r - Enviroments [indexMaterial].GetColor ("_ColorTwo").r) > 0.01f)
				|| (Mathf.Abs (myMaterial.GetColor ("_ColorTwo").g - Enviroments [indexMaterial].GetColor ("_ColorTwo").g) > 0.01f)
				|| (Mathf.Abs (myMaterial.GetColor ("_ColorTwo").b - Enviroments [indexMaterial].GetColor ("_ColorTwo").b) > 0.01f)
				|| (Mathf.Abs (myMaterial.GetFloat ("_YOffset") - Enviroments [indexMaterial].GetFloat ("_YOffset")) > 0.01f)) {
				TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_YOffset"), Enviroments [indexMaterial].GetFloat ("_YOffset"), lerpFloatSpeed);
				myMaterial.SetFloat ("_YOffset", TransitionFloat);

				TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_YScale"), Enviroments [indexMaterial].GetFloat ("_YScale"), lerpFloatSpeed);
				myMaterial.SetFloat ("_YScale", TransitionFloat);

				TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_Emit"), Enviroments [indexMaterial].GetFloat ("_Emit"), lerpFloatSpeed);
				myMaterial.SetFloat ("_Emit", TransitionFloat);

				TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_VertOffset"), Enviroments [indexMaterial].GetFloat ("_VertOffset"), lerpFloatSpeed);
				myMaterial.SetFloat ("_VertOffset", TransitionFloat);

				TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_VertWobble"), Enviroments [indexMaterial].GetFloat ("_VertWobble"), lerpFloatSpeed);
				myMaterial.SetFloat ("_VertWobble", TransitionFloat);

				TransitionFloat = Mathf.Lerp (myMaterial.GetFloat ("_VertWobbleSpeed"), Enviroments [indexMaterial].GetFloat ("_VertWobbleSpeed"), lerpFloatSpeed);
				myMaterial.SetFloat ("_VertWobbleSpeed", TransitionFloat);

				TransitionColor = Color.Lerp (myMaterial.GetColor ("_ColorTwo"), Enviroments [indexMaterial].GetColor ("_ColorTwo"), lerpColorSpeed);
				myMaterial.SetColor ("_ColorTwo", TransitionColor);

				TransitionColor = Color.Lerp (myMaterial.GetColor ("_ColorOne"), Enviroments [indexMaterial].GetColor ("_ColorOne"), lerpColorSpeed);
				myMaterial.SetColor ("_ColorOne", TransitionColor);

				TransitionColor = Color.Lerp (myMaterial.GetColor ("_ShadeColor"), Enviroments [indexMaterial].GetColor ("_ShadeColor"), lerpColorSpeed);
				myMaterial.SetColor ("_ShadeColor", TransitionColor);

				snapThisFloat = true;
			} else if (snapThisFloat) {
				snapThisFloat = false;
				myMaterial.SetFloat ("_VertOffset", Enviroments [indexMaterial].GetFloat ("_VertOffset"));
				myMaterial.SetFloat ("_YOffset", Enviroments [indexMaterial].GetFloat ("_YOffset"));
				myMaterial.SetFloat ("_YScale", Enviroments [indexMaterial].GetFloat ("_YScale"));
				myMaterial.SetFloat ("_Emit", Enviroments [indexMaterial].GetFloat ("_Emit"));
				myMaterial.SetFloat ("_VertOffset", Enviroments [indexMaterial].GetFloat ("_VertOffset"));
				myMaterial.SetFloat ("_VertWobble", Enviroments [indexMaterial].GetFloat ("_VertWobble"));
				myMaterial.SetFloat ("_VertWobbleSpeed", Enviroments [indexMaterial].GetFloat ("_VertWobbleSpeed"));

				myMaterial.SetColor ("_ColorTwo", Enviroments [indexMaterial].GetColor ("_ColorTwo"));
				myMaterial.SetColor ("_ColorOne", Enviroments [indexMaterial].GetColor ("_ColorOne"));
				myMaterial.SetColor ("_ShadeColor", Enviroments [indexMaterial].GetColor ("_ShadeColor"));
			}
		}
	}
}
