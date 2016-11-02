using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum ColorCode { Base, Accent, Accent2, Glass, Column, ColumnFoot, Roofing1, Roofing2, Inside,BaseBack}

[ExecuteInEditMode]
public class ColorManager : MonoBehaviour {

	//remove later
    public static Color ghostColor;
    public static Color invalidMoveColor;

	public Color valid_ghost;
	public Color invalid_ghost;

    public Color _invalidMoveColor;
	public static int ActiveColorScheme = 1;
	public float TotalColorSchemes;

	public Color[] ClrScheme;
	public static int Row = 0;
	public static int Column = 0;
	public float ClrChangeSpeed;

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

	public Color a_Clr1_base;
	public Color a_Clr2_accent;
	public Color a_Clr3_accent_2;
	public Color a_Clr4_glass;
	public Color a_Clr5_column;
	public Color a_Clr6_column_foot;
	public Color a_Clr7_roofing_1;
	public Color a_Clr8_roofing_2;
	public Color a_Clr9_inside;
	public Color a_Clr10_base_back;

	public static Color g_Clr_1_valid;
	public static Color g_Clr_2_valid;
	public static Color g_Clr_3_valid;
	public static Color g_Clr_4_valid;
	public static Color g_Clr_5_valid;
	public static Color g_Clr_6_valid;
	public static Color g_Clr_7_valid;
	public static Color g_Clr_8_valid;
	public static Color g_Clr_9_valid;
	public static Color g_Clr_10_valid;

	public static Color g_Clr_1_invalid;
	public static Color g_Clr_2_invalid;
	public static Color g_Clr_3_invalid;
	public static Color g_Clr_4_invalid;
	public static Color g_Clr_5_invalid;
	public static Color g_Clr_6_invalid;
	public static Color g_Clr_7_invalid;
	public static Color g_Clr_8_invalid;
	public static Color g_Clr_9_invalid;
	public static Color g_Clr_10_invalid;

	// Use this for initialization
	void Start () 
		{
        	invalidMoveColor = _invalidMoveColor;
    	}
	
	// Update is called once per frame
	void Update () 
	{
		TotalColorSchemes = Mathf.Floor((ClrScheme.Length - 1) / 10);

		g_Clr_1_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr1_base.a);
		g_Clr_2_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr2_accent.a);
		g_Clr_3_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr3_accent_2.a);
		g_Clr_4_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr4_glass.a);
		g_Clr_5_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr5_column.a);
		g_Clr_6_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr6_column_foot.a);
		g_Clr_7_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr7_roofing_1.a);
		g_Clr_8_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr8_roofing_2.a);
		g_Clr_9_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr9_inside.a);
		g_Clr_10_valid = new Color (valid_ghost.r, valid_ghost.g, valid_ghost.b, a_Clr10_base_back.a);

		g_Clr_1_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr1_base.a);
		g_Clr_2_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr2_accent.a);
		g_Clr_3_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr3_accent_2.a);
		g_Clr_4_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr4_glass.a);
		g_Clr_5_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr5_column.a);
		g_Clr_6_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr6_column_foot.a);
		g_Clr_7_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr7_roofing_1.a);
		g_Clr_8_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr8_roofing_2.a);
		g_Clr_9_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr9_inside.a);
		g_Clr_10_invalid = new Color (invalid_ghost.r, invalid_ghost.g, invalid_ghost.b, a_Clr10_base_back.a);

		Clr_1 = Color.Lerp (Clr_1, ClrScheme [((ActiveColorScheme)*10) + 1], ClrChangeSpeed);
		Clr_2 = Color.Lerp (Clr_2, ClrScheme [((ActiveColorScheme)*10) + 2], ClrChangeSpeed);
		Clr_3 = Color.Lerp (Clr_3, ClrScheme [((ActiveColorScheme)*10) + 3], ClrChangeSpeed);
		Clr_4 = Color.Lerp (Clr_4, ClrScheme [((ActiveColorScheme)*10) + 4], ClrChangeSpeed);
		Clr_5 = Color.Lerp (Clr_5, ClrScheme [((ActiveColorScheme)*10) + 5], ClrChangeSpeed);
		Clr_6 = Color.Lerp (Clr_6, ClrScheme [((ActiveColorScheme)*10) + 6], ClrChangeSpeed);
		Clr_7 = Color.Lerp (Clr_7, ClrScheme [((ActiveColorScheme)*10) + 7], ClrChangeSpeed);
		Clr_8 = Color.Lerp (Clr_8, ClrScheme [((ActiveColorScheme)*10) + 8], ClrChangeSpeed);
		Clr_9 = Color.Lerp (Clr_9, ClrScheme [((ActiveColorScheme)*10) + 9], ClrChangeSpeed);
		Clr_10 = Color.Lerp (Clr_10, ClrScheme [((ActiveColorScheme)*10) + 10], ClrChangeSpeed);
	}
}
