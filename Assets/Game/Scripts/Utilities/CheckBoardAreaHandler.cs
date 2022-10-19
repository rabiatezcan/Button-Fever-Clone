using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoardAreaHandler : MonoBehaviour
{
    private GridCell[,] _cells;
    private List<Vector3> _positions;
    private int _counter;
    private static CheckBoardAreaHandler _checkBoardAreaHandler;
    public static CheckBoardAreaHandler Instance => _checkBoardAreaHandler;

    public void Initialize(LevelController levelController)
    {
        _checkBoardAreaHandler = this;
        _positions = new List<Vector3>();
        _cells = levelController.CurrentLevel.GridCells;
        _counter = 0;
    }

    
    public void CheckBoardArea(Button button)
    {
        SetDefault();
        SetPositions(button.GetBodyPositions());
        CheckPositionsMatch();

        if (IsMatch())
            button.DropPosition = GetMidPoint() + (Vector3.up * .5f);
        else
            button.ReturnDefaultPosition();
    }
    private void SetDefault()
    {
        _counter = 0;
        _positions.Clear();
    }

    private void SetPositions(List<Vector3> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 pos = RoundPosition(positions[i]);
            pos.y = 0f;
            _positions.Add(pos);
        }
    }

    private void CheckPositionsMatch()
    {
        foreach (var cell in _cells)
        {
            for (int i = 0; i < _positions.Count; i++)
            {
                if ((cell.transform.position == _positions[i]) && cell.IsPlaceable)
                {
                    cell.IsPlaceable = false;
                    _counter++;
                }
            }
        }
    }

    private bool IsMatch()
    {
        return _counter == _positions.Count;
    }
    private Vector3 RoundPosition(Vector3 pos)
    {
        Vector3 newPos = Vector3Int.RoundToInt((pos * 2f));
        newPos /= 2f;
        newPos.y = 0f;

        return newPos;
    }

    private Vector3 GetMidPoint()
    {
        float xSum = 0f, zSum = 0f;
        foreach (var pos in _positions)
        {
            xSum += pos.x;
            zSum += pos.z; 
        }
        return new Vector3(xSum, 0f, zSum) / _positions.Count;
    }

  
}
