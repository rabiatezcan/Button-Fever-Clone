using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    [SerializeField] private TextMeshPro _coinText;

    private int _coin;

    public void Initialize()
    {
        _coin = PlayerHelper.Instance.Player.TotalCoin;
        SetText();
    }
    private void SetText()
    {
        _coinText.text = "$" + _coin;
    }

    private void UpdateMonitorTextArea()
    {
        if (_coin == PlayerHelper.Instance.Player.TotalCoin)
            return;

        _coin = PlayerHelper.Instance.Player.TotalCoin;
        SetText();
    }
    private void Update()
    {
        UpdateMonitorTextArea();
    }
}
