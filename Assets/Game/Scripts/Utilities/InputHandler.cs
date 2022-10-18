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
            OnMouseButton?.Invoke(GetMousePositionOnGrid());
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseButtonUp?.Invoke();
        }
    }

    private Vector3 GetMousePositionOnGrid()
    {
        Vector3 mousePos = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out var enter))
        {
            mousePos = ray.GetPoint(enter);
            //mousePos = Vector3Int.RoundToInt((mousePos * 2f));
            //mousePos /= 2f;
        }
        return mousePos;
    }

}
