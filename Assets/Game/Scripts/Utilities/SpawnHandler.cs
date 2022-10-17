using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    private LevelController _levelController;
    public void Initialize(LevelController levelController)
    {
        _levelController = levelController;
    }
    public void Spawn()
    {
        if (!CanSpawn())
            return;
        var button = PoolHandler.Instance.GetItemFromPool("Button") as Button;
        button.SetPosition(_levelController.CurrentLevel.GetSpawnPoint() + Vector3.up);
        button.SetActive();
    }

    private bool CanSpawn()
    {
        var pos = _levelController.CurrentLevel.GetSpawnPoint();

        if (pos == Vector3.zero)
            return false;
        else
            return true;
    }
}
