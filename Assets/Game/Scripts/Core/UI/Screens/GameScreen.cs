using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Screen
{
    [SerializeField] private CoinView _coinView;
    [SerializeField] private List<UpgradeObject> _upgradeObjects;

    public override void Show()
    {
        _coinView.Initialize();
        _upgradeObjects.ForEach(obj =>
        {
            obj.Initialize();
            ScoreSystem.OnCoinChanged += obj.CheckUpgradable;
        });
        base.Show();
    }

    public override void Hide()
    {
        _upgradeObjects.ForEach(obj => ScoreSystem.OnCoinChanged -= obj.CheckUpgradable);
        base.Hide();
    }
    private void Update()
    {
        _coinView.UpdateTextArea();
    }
}
