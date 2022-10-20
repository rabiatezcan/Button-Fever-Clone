using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtonCoinUpgrade : UpgradeObject
{
    [SerializeField] private SpawnHandler _spawnHandler;

    public override void Initialize()
    {
        Refresh();
    }

    public override void CheckUpgradable()
    {
        if (ScoreSystem.GetCurrentCoin() >= PlayerHelper.Instance.Player.UpgradeSpawnButtonCoinAmount)
        {
            _upgradeButton.interactable = true;
        }
        else
        {
            _upgradeButton.interactable = false;
        }
    }

    public override void Refresh()
    {
        SetAmountForUpgradeText();
        CheckUpgradable();
    }

    public override void SetAmountForUpgradeText()
    {
        _amountForUpgradeText.text = "$" + PlayerHelper.Instance.Player.UpgradeSpawnButtonCoinAmount;
    }

    public override void SetCurrentValueText()
    {
    }

    public override void Upgrade()
    {
        _spawnHandler.Spawn();
        PlayerHelper.Instance.UpgradeSpawnButtonCoinAmount();
        Refresh();
    }

}
