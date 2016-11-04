using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMode : MonoBehaviour {

    SiteManager siteManagerRef;
    SiteData siteDataRef;
    public GameObject tutorial_no_up;
	public GameObject UIX_onGameStart;
	public static bool TutorialStart = false;

	public GameObject Message_base;

	public GameObject[] Messages_;
	bool[] Message_on_;
	bool[] messageShown;

	public float MessageSize;
	private float MessageSmallSize = 6;

	public int message_1_block = 1;
	public int message_2_block = 3;
	public int message_3_block = 5;
	public int message_4_block = 7;
	public int message_5_block = 9;

    void Awake()
    {
        siteManagerRef = FindObjectOfType<SiteManager>();
        siteDataRef = GetComponent<SiteData>();
		UIX_onGameStart.SetActive (true);

        
    }

    // Use this for initialization
    void Start () {
		Message_on_ = new bool[Messages_.Length];
		messageShown = new bool[Messages_.Length];
	}
	
	// Update is called once per frame
	void Update () {
			if (Message_on_ [0] == true) {
				Messages_ [0].gameObject.SetActive (true);
				Message_base.SetActive (true);
				Messages_ [0].transform.localScale = Vector3.Lerp (Messages_ [0].transform.localScale, Vector3.one * MessageSize, 0.05f);
			} else if (Message_on_ [1] == true) {
				Messages_ [1].gameObject.SetActive (true);
				Message_base.SetActive (true);
				Messages_ [1].transform.localScale = Vector3.Lerp (Messages_ [1].transform.localScale, Vector3.one * MessageSize, 0.05f);
			} else if (Message_on_ [2] == true) {
				Messages_ [2].gameObject.SetActive (true);
				Message_base.SetActive (true);
				Messages_ [2].transform.localScale = Vector3.Lerp (Messages_ [2].transform.localScale, Vector3.one * MessageSize, 0.05f);
			} else if (Message_on_ [3] == true) {
				Messages_ [3].gameObject.SetActive (true);
				Message_base.SetActive (true);
				Messages_ [3].transform.localScale = Vector3.Lerp (Messages_ [3].transform.localScale, Vector3.one * MessageSize, 0.05f);
			} else if (Message_on_ [4] == true) {
				Messages_ [4].gameObject.SetActive (true);
				Message_base.SetActive (true);
				Messages_ [4].transform.localScale = Vector3.Lerp (Messages_ [4].transform.localScale, Vector3.one * MessageSize, 0.05f);
			} else {
				Message_base.SetActive (false);
				Messages_ [0].gameObject.SetActive (false);
				Messages_ [1].gameObject.SetActive (false);
				Messages_ [2].gameObject.SetActive (false);
				Messages_ [3].gameObject.SetActive (false);
				Messages_ [4].gameObject.SetActive (false);
				Messages_ [0].transform.localScale = Vector3.Lerp (Messages_ [0].transform.localScale, Vector3.one * MessageSmallSize, 0.1f);
				Messages_ [1].transform.localScale = Vector3.Lerp (Messages_ [1].transform.localScale, Vector3.one * MessageSmallSize, 0.1f);
				Messages_ [2].transform.localScale = Vector3.Lerp (Messages_ [2].transform.localScale, Vector3.one * MessageSmallSize, 0.1f);
				Messages_ [3].transform.localScale = Vector3.Lerp (Messages_ [3].transform.localScale, Vector3.one * MessageSmallSize, 0.1f);
				Messages_ [4].transform.localScale = Vector3.Lerp (Messages_ [4].transform.localScale, Vector3.one * MessageSmallSize, 0.1f);
			}

			if (!messageShown [0] && siteDataRef.currentBlock == message_1_block) {
				MessageState_External (0, "on");
				//print("This is the first block to spawn!");
			}
			if (!messageShown [1] && siteDataRef.currentBlock == message_2_block) {
				MessageState_External (1, "on");
				//print("Now it's the third!");
			}
			if (!messageShown [2] && siteDataRef.currentBlock == message_3_block) {
				MessageState_External (2, "on");
				//print("Now it's the third!");
			}
			if (!messageShown [3] && siteDataRef.currentBlock == message_4_block) {
				MessageState_External (3, "on");
				//print("Now it's the third!");
			}
			if (!messageShown [4] && siteDataRef.currentBlock == message_5_block) {
				MessageState_External (4, "on");
				//print("Now it's the third!");
			}
	}

    public void SetUpPillar(int gridSizeX, int gridSizeY)
    {
        siteDataRef.grid = new Block[gridSizeX, gridSizeY];

        for (int i = 0; i < 5; i++)
        {
            if (i == 2)
                continue;
            GameObject block = Instantiate(tutorial_no_up, siteDataRef.transform);
            Block new_no_up = block.GetComponent<Block>();
            new_no_up.SetGridPos(new Vector2(i, 0), false);
            new_no_up.Drop();
        }
    }

	public void MessageState_External (int number, string state)
	{
		if (number == 0) {
			if (state == "on") {
				MessageState_Internal ("on", Messages_[0], 0);
				MessageState_Internal ("off", Messages_[1], 1);
				MessageState_Internal ("off", Messages_[2], 2);
				MessageState_Internal ("off", Messages_[3], 3);
				MessageState_Internal ("off", Messages_[4], 4);
				messageShown [0] = true;
			}
			if (state == "off") {
				MessageState_Internal ("off", Messages_[number], number);
			}
		}
		if (number == 1) {
			if (state == "on") {
				MessageState_Internal ("off", Messages_[0], 0);
				MessageState_Internal ("on", Messages_[1], 1);
				MessageState_Internal ("off", Messages_[2], 2);
				MessageState_Internal ("off", Messages_[3], 3);
				MessageState_Internal ("off", Messages_[4], 4);
				messageShown [1] = true;
			}
			if (state == "off") {
				MessageState_Internal ("off", Messages_[number], number);
			}
		}
		if (number == 2) {
			if (state == "on") {
				MessageState_Internal ("off", Messages_[0], 0);
				MessageState_Internal ("off", Messages_[1], 1);
				MessageState_Internal ("on", Messages_[2], 2);
				MessageState_Internal ("off", Messages_[3], 3);
				MessageState_Internal ("off", Messages_[4], 4);
				messageShown [2] = true;
			}
			if (state == "off") {
				MessageState_Internal ("off", Messages_[number], number);
			}
		}
		if (number == 3) {
			if (state == "on") {
				MessageState_Internal ("pff", Messages_[0], 0);
				MessageState_Internal ("off", Messages_[1], 1);
				MessageState_Internal ("off", Messages_[2], 2);
				MessageState_Internal ("on", Messages_[3], 3);
				MessageState_Internal ("off", Messages_[4], 4);
				messageShown [3] = true;
			}
			if (state == "off") {
				MessageState_Internal ("off", Messages_[number], number);
			}
		}
		if (number == 4) {
			if (state == "on") {
				MessageState_Internal ("off", Messages_[0], 0);
				MessageState_Internal ("off", Messages_[1], 1);
				MessageState_Internal ("off", Messages_[2], 2);
				MessageState_Internal ("off", Messages_[3], 3);
				MessageState_Internal ("on", Messages_[4], 4);
				messageShown [4] = true;
			}
			if (state == "off") {
				MessageState_Internal ("off", Messages_[number], number);
			}
		}
	}

	public void Messages_off () 
	{
		Debug.Log ("all messages off");
		MessageState_Internal ("off", Messages_[0], 0);
		MessageState_Internal ("off", Messages_[1], 1);
		MessageState_Internal ("off", Messages_[2], 2);
		MessageState_Internal ("off", Messages_[3], 3);
		MessageState_Internal ("off", Messages_[4], 4);
	}

	void MessageState_Internal (string state, GameObject messageNumber, int number) 
	{
		if (state == "on") {
			messageNumber.gameObject.SetActive (true);
			Message_on_ [number] = true;
		}
		if (state == "off") {
			messageNumber.gameObject.SetActive (false);
			Message_on_ [number] = false;
		}
	}
}
