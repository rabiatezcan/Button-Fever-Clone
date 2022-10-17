using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler 
{
    public Action OnMouseButtonDown;
    public Action<Vector2> OnMouseButton;
    public Action OnMouseButtonUp;

    private Vector2 _previousPos;
    private Vector2 _mousePos;
    private Vector2 _currentPos;
    private Vector2 _deltaPos;
    private float _sensitivity = 1f;

    public Vector2 DeltaPos => _deltaPos;

    public void RemoveInputs()
    {
        _deltaPos = Vector2.zero;
        _previousPos = Vector2.zero;
        _mousePos = Vector2.zero;
        _currentPos = Vector2.zero;
    }

    public void Update()
    {
        InputUpdate();
    }

    private void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Input.mousePosition;
            _currentPos = _mousePos;
            _previousPos = _mousePos;

            OnMouseButtonDown?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            _currentPos = Input.mousePosition;
            _deltaPos = (_currentPos - _previousPos) * _sensitivity;

            _previousPos = _currentPos;

            OnMouseButton?.Invoke(_deltaPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _deltaPos = Vector3.zero;

            OnMouseButtonUp?.Invoke();
        }
    }

}
