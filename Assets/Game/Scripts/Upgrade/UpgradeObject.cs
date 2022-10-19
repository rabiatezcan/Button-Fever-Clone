using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeObject : MonoBehaviour
{
    public Action OnUpgrade;

    [SerializeField] protected UnityEngine.UI.Button _upgradeButton;
    [SerializeField] protected Text _currentValueTxt;
    [SerializeField] protected Text _amountForUpgradeText;
    [SerializeField] protected bool _isButtonActive;

    public abstract void Initialize();
    public abstract void Refresh();
    public abstract void SetCurrentValueText();
    public abstract void SetAmountForUpgradeText();
    public abstract void CheckUpgradable();
    public abstract void Upgrade();
}
