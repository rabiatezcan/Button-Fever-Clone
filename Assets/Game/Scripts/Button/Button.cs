using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Button : PoolObject, ISelectableObject
{
    [SerializeField] private ButtonBody _body;

    private GameEnums.ButtonTypes _currentType;

    private Vector3 _selectionOffset;
    private float _zAxisPosition;
    public void Initialize()
    {
        _body.Initialize(_currentType);
    }
    #region ISelectable
    public void Select()
    {
        _zAxisPosition = Camera.main.WorldToScreenPoint(transform.position).z;
        _selectionOffset = transform.position - GetMouseWorldPosition();
    }
    public void Drag(Vector2 inputPos)
    {
        Vector3 pos = GetMouseWorldPosition() + _selectionOffset;
        pos.y = 0f;
        transform.position = pos;
    }

    public void Drop()
    {
        _selectionOffset.z = 0f;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 position = Input.mousePosition;

        position.z = _zAxisPosition;

        return Camera.main.ScreenToWorldPoint(position);
    }
    #endregion


    #region Trigger Behaviour

    public void TriggerEnterBehaviour(Collider other)
    {

    }
    public void TriggerExitBehaviour(Collider other)
    {

    }
    #endregion
}
