using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGrid : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _width;

    private GridCell[,] gridCells;
    
    public void Initialize()
    {
        gridCells = new GridCell[_width, _height];
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                GridCell cell = PoolHandler.Instance.GetItemFromPool("GridCell") as GridCell;
                cell.SetPosition(new Vector3((i * 1.5f) - 4f, 0f, (j*1.5f) - 5f));
                cell.Initialize(); 
                cell.SetActive();
            }
        }
    }
}
