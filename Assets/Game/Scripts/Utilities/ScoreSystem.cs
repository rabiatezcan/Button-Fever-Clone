using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem
{
    private static int _currentCoin;

    public static void AddCoin(int value)
    {
        _currentCoin += value; 
        PlayerHelper.Instance.UpdateCoin(value);
    }

    public static void DecreaseCoin(int value)
    {
        _currentCoin -= value; 
    }

    public static int GetCurrentCoin()
    {
        return _currentCoin;
    }
    public static void Reload()
    {
        _currentCoin = 0; 
    }
}
