using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    public void Initialize()
    {
        LoadPlayerData();
        LoadButtonData();
    }

    private void LoadPlayerData()
    {
        object data = SaveSystem.Load(CONSTANTS.PLAYER_DATA_FOLDER_PATH);
        PlayerHelper.Instance.UpdatePlayerData(data);
    }

    private void LoadButtonData()
    {
        for (int i = 0; i < PlayerHelper.Instance.Player.ActiveButtonCount; i++)
        {
            ButtonData data = SaveSystem.Load(CONSTANTS.BUTTON_DATA_FOLDER_PATH + i) as ButtonData;
            PlayerHelper.Instance.AddButtonData(data);
        }
    }

    [ContextMenu("Reset Data")]
    private void ResetData()
    {
        PlayerHelper.Instance.ResetPlayerData();
        PlayerHelper.Instance.ClearButtons();
    }

    private void OnApplicationQuit()
    {
#if UNITY_EDITOR
        PlayerHelper.Instance.UpdateCoin(ScoreSystem.GetCurrentCoin());
        PlayerHelper.Instance.UpdateActiveButtonCount();
        PlayerHelper.Instance.SaveButtonData();
#endif

    }
}
