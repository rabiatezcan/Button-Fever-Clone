using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AutomatedPushTimerUpgrade : UpgradeObject
{
    public override void Initialize()
    {
        Refresh();
    }

    public override void CheckUpgradable()
    {
        if (ScoreSystem.GetCurrentCoin() >= PlayerHelper.Instance.Player.UpgradeAutomatedPushTimeAmount)
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
        SetCurrentValueText();
        SetAmountForUpgradeText();
        CheckUpgradable();
    }

    public override void SetAmountForUpgradeText()
    {
        _amountForUpgradeText.text = "$" + PlayerHelper.Instance.Player.UpgradeAutomatedPushTimeAmount;
    }

    public override void SetCurrentValueText()
    {
        _currentValueTxt.text = PlayerHelper.Instance.Player.AutomatedPushTime + "s";
    }

    public override void Upgrade()
    {
        PlayerHelper.Instance.UpgradeAutomatedPushTime();
        Refresh();
    }
}
