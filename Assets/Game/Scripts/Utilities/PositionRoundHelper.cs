using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionRoundHelper 
{
    public static Vector3 RoundPosition(Vector3 pos)
    {
        Vector3 newPos = Vector3Int.RoundToInt((pos * 2f));
        newPos /= 2f;
        newPos.y = 0f;

        return newPos;
    }
}
