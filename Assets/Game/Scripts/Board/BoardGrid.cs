using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGrid : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private float _widthOffset;
    [SerializeField] private float _heightOffset;
    private GridCell[,] _gridCells;

    public GridCell[,] GridCells => _gridCells;

    public void Initialize()
    {
        _gridCells = new GridCell[_width, _height];
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                GridCell cell = PoolHandler.Instance.GetItemFromPool("GridCell") as GridCell;
                cell.SetPosition(new Vector3((i * CONSTANTS.GRID_CELL_SCALE_AMOUNT) - _widthOffset, 0f, (j * CONSTANTS.GRID_CELL_SCALE_AMOUNT) - _heightOffset));
                cell.Initialize(); 
                cell.SetActive();

                _gridCells[i,j] = cell;
            }
        }
    }
}
