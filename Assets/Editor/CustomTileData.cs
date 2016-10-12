using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(TileData))]
public class CustomTileData : PropertyDrawer
{
    float heightBelowLabel = 18;
    float elementSpace = 65;
    float inspectorHeight = 100;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);

        Rect newPosition = position;
        newPosition.y += heightBelowLabel;
        //not really sure what this does
        newPosition.height = 20;

        SerializedProperty col = property.FindPropertyRelative("col");
        for (int i = 0; i < col.arraySize; i++)
        {
            SerializedProperty row = col.GetArrayElementAtIndex(i).FindPropertyRelative("row");
            //not really sure what this is for
            if (row.arraySize != col.arraySize)
                row.arraySize = col.arraySize;

            newPosition.width = elementSpace;

            for (int j = row.arraySize - 1; j >= 0; j--)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(j), GUIContent.none);

                newPosition.y += elementSpace/2;
            }
            newPosition.y = position.y + heightBelowLabel;
            newPosition.x += newPosition.width;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return inspectorHeight;
    }
}