﻿using UnityEngine;
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
        if (xLength == 0)
            return;

        column[] oldCol = col;
        column[] newCol = {
            oldCol[2],
            oldCol[1],
            oldCol[0] };

        bool leftEdgeEmpty = false;
        foreach (Tile tile in newCol[0].row)
        {
            if (tile != Tile.Empty)
            {
                leftEdgeEmpty = false;
                break;
            }
            else
            {
                leftEdgeEmpty = true;
            }
        }

        if(leftEdgeEmpty)
        {
            column[] newCol1 = newCol;
            column[] newCol2 = {
                    newCol1[1],
                    newCol1[2],
                    newCol1[0] };
            newCol = newCol2;
        }
        col = newCol;
    }

    public int xLength
    {
        get
        {
            int _xLength = 0;
            foreach (Vector2 tile in AllTileCoords)
            {
                if (tile.x > _xLength)
                {
                    _xLength = (int)tile.x;
                }
            }
            return _xLength;
        }
    }

    public int yLength
    {
        get
        {
            int _yLength = 0;
            foreach (Vector2 tile in AllTileCoords)
            {
                if (tile.y > _yLength)
                {
                    _yLength = (int)tile.y;
                }
            }
            return _yLength;
        }
    }

}
