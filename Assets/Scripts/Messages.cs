using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour {

	public GameObject Message_1;
	public TimeController _TimeController;

    void Awake()
    {
        _TimeController = FindObjectOfType<TimeController>();
    }

	// Use this for initialization
	void Start () {
		
		Message_1.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //TODO: This can be simplified into one function.
	public void Message_1_on () 
	{
		if (Message_1.activeSelf == false) {
			Message_1.SetActive (true);
		}
	}

	public void Message_1_off () 
	{
		if (Message_1.activeSelf == true) {
			Message_1.SetActive (false);
			_TimeController.StartNewDay ();
		}
	}
}
