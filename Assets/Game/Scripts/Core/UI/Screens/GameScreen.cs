using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Screen
{
    [SerializeField] private CoinView _coinView;

    public override void Show()
    {
        _coinView.Initialize();
        base.Show();
    }
    private void Update()
    {
        _coinView.UpdateTextArea();
    }
}
