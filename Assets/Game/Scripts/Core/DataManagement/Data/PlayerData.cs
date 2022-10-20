using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class PlayerData
{
    public int TotalCoin { get; set; }
    public int Coin { get; set; }
    public int Level { get; set; }
    public float AutomatedPushTime { get; set; }
    public int UpgradeSpawnButtonCoinAmount { get; set; }
    public int UpgradeAutomatedPushTimeAmount { get; set; }

    public void SetUpgradeAmountForSpawnButtonCoin()
    {
        UpgradeSpawnButtonCoinAmount = ((int)Mathf.Ceil(UpgradeSpawnButtonCoinAmount * CONSTANTS.UPGRADE_AMOUNT_MULTIPLIER));
    }
    public void SetUpgradeAmountForAutomatedPushTime()
    {
        UpgradeAutomatedPushTimeAmount = ((int)Mathf.Ceil(UpgradeAutomatedPushTimeAmount * CONSTANTS.UPGRADE_AMOUNT_MULTIPLIER));
    }

    public void Build()
    {
        TotalCoin = 0;
        Coin = 0;
        Level = 1;
        AutomatedPushTime = 2.5f;
        UpgradeSpawnButtonCoinAmount = 10;
        UpgradeAutomatedPushTimeAmount = 10;
    }





}
