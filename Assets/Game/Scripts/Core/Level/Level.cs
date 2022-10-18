using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private ButtonSpawnArea _spawnArea;
    [SerializeField] private Board _board;

    public GridCell[,] GridCells => _board.GridCells;

    public void Initialize()
    {
        gameObject.SetActive(true);
        _board.Initialize();
    }
    public void Build()
    {
        Initialize();
    }

    public void Remove()
    {
    }

    public Vector3 GetSpawnPoint()
    {
        return _spawnArea.GetSpawnPoint();
    }
}
