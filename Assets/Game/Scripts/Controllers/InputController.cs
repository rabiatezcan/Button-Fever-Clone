using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    private InputHandler _inputHandler;
    private ISelectableObject _currentObject;

    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _inputHandler = new InputHandler();
    }

    public override void StartGame()
    {
        ListenInputs();
    }

    public override void Reload()
    {
    }

    public override void GameOver()
    {
        StopListenInputs();
        _inputHandler.RemoveInputs();
    }

    #endregion
    private void ListenInputs()
    {
        _inputHandler.OnMouseButtonDown += Select;
        _inputHandler.OnMouseButton += Drag;
        _inputHandler.OnMouseButtonUp += Drop;
    }
    private void StopListenInputs()
    {
        _inputHandler.OnMouseButtonDown -= Select;
        _inputHandler.OnMouseButton -= Drag;
        _inputHandler.OnMouseButtonUp -= Drop;
    }

    public void Select()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f, LayerMask.GetMask("SelectableObject")))
        {
            if (hit.collider != null)
            {
                _currentObject = hit.transform.GetComponentInParent<ISelectableObject>();

                _currentObject.Select();
            }
        }
    }

    public void Drag(Vector2 deltaPos)
    {
        if (_currentObject != null)
            _currentObject.Drag(deltaPos);
    }

    public void Drop()
    {
        if (_currentObject != null)
        {
            _currentObject.Drop();
            _currentObject = null;
        }

    }

    private void Update()
    {
        _inputHandler.Update();
    }

}
