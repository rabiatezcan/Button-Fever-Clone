using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    [SerializeField] private TextMeshPro _coinText;

    private void SetText()
    {
        _coinText.text = "$" + PlayerHelper.Instance.PlayerCoin;
    }

    private void Update()
    {
        SetText();
    }
}
