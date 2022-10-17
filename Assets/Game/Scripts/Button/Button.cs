using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, ISelectableObject
{
    private Vector3 _selectionOffset;
    private float _zAxisPosition;
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
        _selectionOffset.z = GetMouseWorldPosition().z;
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

    #region Trigger Behaviour

    public void TriggerEnterBehaviour(Collider other)
    {

    }
    public void TriggerExitBehaviour(Collider other)
    {

    }
    #endregion
}
