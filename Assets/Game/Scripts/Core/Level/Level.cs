using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private ButtonSpawnArea _spawnArea;
    public void Initialize()
    {
    }
    public void Build()
    {
        gameObject.SetActive(true);
    }

    public void Remove()
    {
    }

    public Vector3 GetSpawnPoint()
    {
        return _spawnArea.GetSpawnPoint();
    }
}
