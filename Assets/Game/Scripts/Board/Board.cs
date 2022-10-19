using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour, ISelectableObject
{
    [SerializeField] private BoardGrid _grid;

    private List<Button> _buttons = new List<Button>();
    public GridCell[,] GridCells => _grid.GridCells;

    private int _totalCoin;

    #region Core
    public void Initialize()
    {
        _grid.Initialize();
        _totalCoin = 0;
    }

    public void StartGame()
    {

    }

    #endregion


    #region ISelectableObject
    public void Select()
    {
        PushButtons();
    }
    public void Drag(Vector3 inputPos)
    {
    }

    public void Drop()
    {
    }

    #endregion

    private void PushButtons()
    { 
        _buttons.ForEach(button => button.Push());
    }

    private void AddElement(Button button)
    {
        _buttons.Add(button);
        _totalCoin += button.ButtonValue;
    }  
    private void RemoveElement(Button button)
    {
        _buttons.Remove(button);
        _totalCoin -= button.ButtonValue;
    }

    #region TriggerBehaviour
    public void TriggerEnterBehaviour(Collider other)
    {
        Button button = other.GetComponentInParent<Button>();
        if (!_buttons.Contains(button))
            AddElement(button);
    }
    public void TriggerExitBehaviour(Collider other)
    {
        Button button = other.GetComponentInParent<Button>();
        if (_buttons.Contains(button))
            RemoveElement(button);
    }
    #endregion

}
