using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler 
{
    public Action<Vector3> OnMouseButtonDown;
    public Action<Vector3> OnMouseButton;
    public Action OnMouseButtonUp;
    
    private Camera _camera;
    private float _zAxisPosition;

    public InputHandler(Camera camera)
    {
        _camera = camera;
        _zAxisPosition = _camera.WorldToScreenPoint(Vector3.forward * 30f).z;
    }
    public void Update()
    {
        InputUpdate();
    }

    private void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown?.Invoke(GetMouseWorldPosition());
        }

        if (Input.GetMouseButton(0))
        {
            OnMouseButton?.Invoke(GetMouseWorldPosition());
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseButtonUp?.Invoke();
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 position = Input.mousePosition;

        position.z = _zAxisPosition;

        return _camera.ScreenToWorldPoint(position);
    }

}
