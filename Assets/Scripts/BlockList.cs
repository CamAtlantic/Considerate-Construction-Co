using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockList : System.Object {

    public GameObject[] list;

    public int Length
    {
        get
        {
            return (list.Length);
        }
    }
}
