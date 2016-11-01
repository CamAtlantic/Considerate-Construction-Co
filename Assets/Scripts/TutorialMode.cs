using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMode : MonoBehaviour {

    SiteManager siteManagerRef;
    SiteData siteDataRef;
    public GameObject tutorial_no_up;

    bool messageShown1 = false;
    bool messageShown2 = false;

    void Awake()
    {
        siteManagerRef = FindObjectOfType<SiteManager>();
        siteDataRef = GetComponent<SiteData>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(!messageShown1 && siteDataRef.currentBlock == 1)
        {
            messageShown1 = true;
            //print("This is the first block to spawn!");
        }
        if (!messageShown2 && siteDataRef.currentBlock == 3)
        {
            messageShown2 = true;

//            print("Now it's the third!");
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
}
