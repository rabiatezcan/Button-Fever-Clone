using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class MidPointHelper
{
    public static Vector3 GetMidPoint(List<Vector3> positions)
    {
        float xSum = 0f, ySum = 0f, zSum = 0f;

        foreach (var pos in positions)
        {
            xSum += pos.x;
            ySum += pos.y; 
            zSum += pos.z;
        }
        return new Vector3(xSum, ySum, zSum) / positions.Count;
    }
}
