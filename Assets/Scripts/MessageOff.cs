using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOff : MonoBehaviour {

	private GameObject me;

	// Use this for initialization
	void Start () {
		me = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Message_Off ()
	{
		me.SetActive (false);
	}
}
