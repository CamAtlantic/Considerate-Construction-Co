﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuidlingControllerScript : MonoBehaviour {

	public float Depth;
	public int MyColorCode;
	public bool Ghost = false;
	public bool Valid = false;

    SpriteRenderer spriteRender;

    bool ghost = false;

    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        
    }

    // Use this for initialization
    void Start () {
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -(Depth / 5 + 1));
	}
	
	// Update is called once per frame
	void Update () {
		spriteRender = GetComponent<SpriteRenderer>();
		UpdateAllColor();
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -(Depth / 5 + 1));
	}

   // public void SetColor(Color color)
    //{
     //   spriteRender.color = color;
    //}

    public void UpdateAllColor()
	{
		if (Ghost == false) {
			if (MyColorCode == 1) {
				spriteRender.color = ColorManager.Clr_1;
			}
			if (MyColorCode == 2) {
				spriteRender.color = ColorManager.Clr_2;
			}
			if (MyColorCode == 3) {
				spriteRender.color = ColorManager.Clr_3;
			}
			if (MyColorCode == 4) {
				spriteRender.color = ColorManager.Clr_4;
			}
			if (MyColorCode == 5) {
				spriteRender.color = ColorManager.Clr_5;
			}
			if (MyColorCode == 6) {
				spriteRender.color = ColorManager.Clr_6;
			}
			if (MyColorCode == 7) {
				spriteRender.color = ColorManager.Clr_7;
			}
			if (MyColorCode == 8) {
				spriteRender.color = ColorManager.Clr_8;
			}
			if (MyColorCode == 9) {
				spriteRender.color = ColorManager.Clr_9;
			}
			if (MyColorCode == 10) {
				spriteRender.color = ColorManager.Clr_10;
			}
		}
		else
		{
			if (Ghost == true) {
				if (Valid == true) {
					if (MyColorCode == 1) {
						spriteRender.color = ColorManager.g_Clr_1_valid;
					}
					if (MyColorCode == 2) {
						spriteRender.color = ColorManager.g_Clr_2_valid;
					}
					if (MyColorCode == 3) {
						spriteRender.color = ColorManager.g_Clr_3_valid;
					}
					if (MyColorCode == 4) {
						spriteRender.color = ColorManager.g_Clr_4_valid;
					}
					if (MyColorCode == 5) {
						spriteRender.color = ColorManager.g_Clr_5_valid;
					}
					if (MyColorCode == 6) {
						spriteRender.color = ColorManager.g_Clr_6_valid;
					}
					if (MyColorCode == 7) {
						spriteRender.color = ColorManager.g_Clr_7_valid;
					}
					if (MyColorCode == 8) {
						spriteRender.color = ColorManager.g_Clr_8_valid;
					}
					if (MyColorCode == 9) {
						spriteRender.color = ColorManager.g_Clr_9_valid;
					}
					if (MyColorCode == 10) {
						spriteRender.color = ColorManager.g_Clr_10_valid;
					}
				}

				if (Valid == false) {
					if (MyColorCode == 1) {
						spriteRender.color = ColorManager.g_Clr_1_invalid;
					}
					if (MyColorCode == 2) {
						spriteRender.color = ColorManager.g_Clr_2_invalid;
					}
					if (MyColorCode == 3) {
						spriteRender.color = ColorManager.g_Clr_3_invalid;
					}
					if (MyColorCode == 4) {
						spriteRender.color = ColorManager.g_Clr_4_invalid;
					}
					if (MyColorCode == 5) {
						spriteRender.color = ColorManager.g_Clr_5_invalid;
					}
					if (MyColorCode == 6) {
						spriteRender.color = ColorManager.g_Clr_6_invalid;
					}
					if (MyColorCode == 7) {
						spriteRender.color = ColorManager.g_Clr_7_invalid;
					}
					if (MyColorCode == 8) {
						spriteRender.color = ColorManager.g_Clr_8_invalid;
					}
					if (MyColorCode == 9) {
						spriteRender.color = ColorManager.g_Clr_9_invalid;
					}
					if (MyColorCode == 10) {
						spriteRender.color = ColorManager.g_Clr_10_invalid;
					}
				}
			}
		}
	}
}
