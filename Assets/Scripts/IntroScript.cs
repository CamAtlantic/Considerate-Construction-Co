using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	public GameObject Intro_Loading;
	public GameObject Intro_Credits;
	public GameObject StartButton;

	private float counter = 0;
	public float count_mark_1;
	public float count_mark_2;

	// Use this for initialization
	void Start () {
		//Intro_Loading.SetActive (true);
		//Intro_Credits.SetActive (false);
		//StartButton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		/*counter += Time.deltaTime;
		if (counter > count_mark_1) 
		{
			Intro_Loading.SetActive (false);
			Intro_Credits.SetActive (true);
		}
		if (counter > count_mark_2) 
		{
			StartButton.SetActive (true);
		}*/
	}

	public void StartTutorial ()
	{
		SceneManager.LoadScene ("2_Tutorial");
	}
}
