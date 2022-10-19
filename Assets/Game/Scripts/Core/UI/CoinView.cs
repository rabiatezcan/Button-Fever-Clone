using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _currentCoin;
    public void Initialize()
    {
        _currentCoin = ScoreSystem.GetCurrentCoin();
        SetText();
    }
    public void UpdateTextArea()
    {
        if (_currentCoin == ScoreSystem.GetCurrentCoin())
            return;

        _currentCoin = ScoreSystem.GetCurrentCoin();
        SetText();
    }
    
    private void SetText()
    {
        _text.text = "$" + _currentCoin;
    }
}
