using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    public void Initialize()
    {
        InitializeSaveSystem();
    }

    private void InitializeSaveSystem()
    {
        object data = SaveSystem.Load();
        PlayerHelper.Instance.UpdatePlayerData(data);
    }

    [ContextMenu("Reset Data")]
    private void ResetData()
    {
        PlayerHelper.Instance.ResetPlayerData();
    }

    private void OnApplicationQuit()
    {
#if UNITY_EDITOR
        PlayerHelper.Instance.UpdateCoin(ScoreSystem.GetCurrentCoin());
#endif

    }
}
