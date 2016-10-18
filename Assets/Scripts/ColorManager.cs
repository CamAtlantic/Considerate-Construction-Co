using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColorManager : MonoBehaviour {

	public static Color Clr_1;
	public static Color Clr_2;
	public static Color Clr_3;
	public static Color Clr_4;
	public static Color Clr_5;
	public static Color Clr_6;
	public static Color Clr_7;
	public static Color Clr_8;
	public static Color Clr_9;
	public static Color Clr_10;

	public Color Clr1_base;
	public Color Clr2_accent;
	public Color Clr3_accent_2;
	public Color Clr4_glass;
	public Color Clr5_column;
	public Color Clr6_column_foot;
	public Color Clr7_roofing_1;
	public Color Clr8_roofing_2;
	public Color Clr9_inside;
	public Color Clr10_base_back;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Clr_1 = Clr1_base;
		Clr_2 = Clr2_accent;
		Clr_3 = Clr3_accent_2;
		Clr_4 = Clr4_glass;
		Clr_5 = Clr5_column;
		Clr_6 = Clr6_column_foot;
		Clr_7 = Clr7_roofing_1;
		Clr_8 = Clr8_roofing_2;
		Clr_9 = Clr9_inside;
		Clr_10 = Clr10_base_back;
		
	}
}
