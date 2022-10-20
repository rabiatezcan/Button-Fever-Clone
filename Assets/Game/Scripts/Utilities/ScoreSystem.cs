using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem
{
    public static Action OnCoinChanged;
    private static int _currentCoin;

    public static void Initialize()
    {
        _currentCoin = PlayerHelper.Instance.Player.Coin;
    }
    public static void AddCoin(int value)
    {
        _currentCoin += value; 
        PlayerHelper.Instance.UpdateTotalCoin(value);
        OnCoinChanged?.Invoke();
    }

    public static void DecreaseCoin(int value)
    {
        _currentCoin -= value;
        OnCoinChanged?.Invoke();
    }

    public static int GetCurrentCoin()
    {
        return _currentCoin;
    }
}
