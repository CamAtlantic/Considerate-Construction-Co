using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum Tile { Empty, Solid, NoDown,NoUp}

[System.Serializable]
public class TileData {

    [System.Serializable]
    public struct column
    {
        public Tile[] row;
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
                if (col[i].row[j] != Tile.Empty)
                {
                    temp.Add(new Vector2(i, j));
                }
            }
        }
        return temp;
    }

    public void FlipHorizontal()
    {
        column[] oldCol = col;
        column[] newCol = {
            oldCol[2],
            oldCol[1],
            oldCol[0] };
        col = newCol;
    }
}
