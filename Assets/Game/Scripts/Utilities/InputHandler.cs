using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    public Action OnMouseButtonDown;
    public Action<Vector3> OnMouseButton;
    public Action OnMouseButtonUp;

    private Plane plane;
    public InputHandler()
    {
        plane = new Plane(Vector3.up, Vector3.zero);
    }
    public void Update()
    {
        InputUpdate();
    }

    private void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            OnMouseButton?.Invoke(GetMousePosition());
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseButtonUp?.Invoke();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out var enter))
        {
            mousePos = ray.GetPoint(enter);
          
        }
        return mousePos;
    }

}
