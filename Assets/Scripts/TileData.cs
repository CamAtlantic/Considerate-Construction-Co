using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TileData  {
    
    [System.Serializable]
    public struct column
    {
        public bool[] row;
    }
    public column[] col = new column[3];

    /// <summary>
    /// A vector2 list of all the coordinates of tiles in the shape, relative to the origin.
    /// </summary>
    public List<Vector2> AllTileCoords
    {
        get
        {
            return GetAllTileCoords();
        }
    }

    List<Vector2> GetAllTileCoords()
    {
        List<Vector2> temp = new List<Vector2>();
        for (int i = 0; i < col.Length; i++)
        {
            for (int j = 0; j < col[0].row.Length; j++)
            {
                if (col[i].row[j])
                {
                    temp.Add(new Vector2(i, j));
                }
            }
        }
        return temp;
    }
}
