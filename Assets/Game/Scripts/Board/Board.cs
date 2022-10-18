using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private BoardGrid _grid;

    public GridCell[,] GridCells => _grid.GridCells;

    public void Initialize()
    {
        _grid.Initialize();
    }
}
