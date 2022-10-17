using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class PlayerData
{
    public int Coin { get; set; }
    public int Level { get; set; }

    public void Build()
    {
        Coin = 0;
        Level = 1;
    }





}
