using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem
{
    private static int _currentScore;

    public static void AddScore(int value)
    {
        _currentScore += value; 
        PlayerHelper.Instance.UpdateCoin(value);
    }

    public static void DecreaseScore(int value)
    {
        _currentScore -= value; 
    }

    public static int GetCurrentScore()
    {
        return _currentScore;
    }
    public static void Reload()
    {
        _currentScore = 0; 
    }
}
