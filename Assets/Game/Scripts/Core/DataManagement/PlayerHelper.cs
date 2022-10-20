using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper
{
    private PlayerData _playerData;

    private static PlayerHelper _playerHelper;
    private static List<Button> _buttons = new List<Button>();
    private static List<ButtonData> _buttonDatas = new List<ButtonData>();
    public PlayerHelper()
    {
        _playerData = new PlayerData();
        ResetPlayerData();
    }
    
    public static PlayerHelper Instance
    {
        get
        {
            if (_playerHelper == null)
            {
                _playerHelper = new PlayerHelper();
            }

            return _playerHelper;
        }
    }

    public PlayerData Player => _playerData;

    #region PlayerData
    private void SavePlayerData()
    {
        SaveSystem.Save(CONSTANTS.PLAYER_DATA_FOLDER_PATH, _playerData);
    }
    public void UpdatePlayerData(object data)
    {
        _playerData = data as PlayerData;
    }
    public void ResetPlayerData()
    {
        _playerData.Build();

        SavePlayerData();
    }

    public void UpdateTotalCoin(int amount)
    {
        _playerData.TotalCoin += amount;

        SavePlayerData();
    }
    public void UpdateCoin(int amount)
    {
        _playerData.Coin = amount;

        SavePlayerData();
    } 
    public void UpdateActiveButtonCount()
    {
        _playerData.ActiveButtonCount = _buttons.Count;

        SavePlayerData();
    }
    
    public void UpgradeSpawnButtonCoinAmount()
    {
        ScoreSystem.DecreaseCoin(_playerData.UpgradeSpawnButtonCoinAmount);
        _playerData.SetUpgradeAmountForSpawnButtonCoin();

        SavePlayerData();
    }  
    public void UpgradeAutomatedPushTime()
    {
        _playerData.AutomatedPushTime += CONSTANTS.DEFAULT_UPGRADE_AMOUNT_PUSH_TIMER;
        ScoreSystem.DecreaseCoin(_playerData.UpgradeAutomatedPushTimeAmount);
        _playerData.SetUpgradeAmountForAutomatedPushTime();

        SavePlayerData();
    }
    #endregion

    #region ButtonData
    public void SaveButtonData()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            ButtonData data = new ButtonData(_buttons[i]);
            SaveSystem.Save(CONSTANTS.BUTTON_DATA_FOLDER_PATH + i, data);
        }
    }

    public void SetActiveButtons()
    {
        for (int i = 0; i < _buttonDatas.Count; i++)
        {
            Button button = PoolHandler.Instance.GetItemFromPool("Button") as Button;
            button.SetPosition(new Vector3(_buttonDatas[i].Position[0], _buttonDatas[i].Position[1], _buttonDatas[i].Position[2]));
            button.CurrentType = (GameEnums.ButtonTypes)_buttonDatas[i].CurrentType;
            button.SetActive();
        }
    }

    public void AddButtonData(ButtonData data)
    {
        _buttonDatas.Add(data);
    }
    public void AddButton(Button button)
    {
        _buttons.Add(button);
    }

    public void RemoveButton(Button button)
    {
        if (_buttons.Contains(button))
            _buttons.Remove(button);
    }

    public void ClearButtons()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            SaveSystem.DeleteFolder(CONSTANTS.BUTTON_DATA_FOLDER_PATH + i);
        }
        _buttons.Clear();
        _buttonDatas.Clear();
    }
    #endregion
}
