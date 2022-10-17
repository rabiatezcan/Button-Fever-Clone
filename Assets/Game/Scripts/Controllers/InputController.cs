using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    [SerializeField] Camera _camera;

    private InputHandler _inputHandler;
    private ISelectableObject _currentObject;

    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _inputHandler = new InputHandler(_camera);
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

    public void Select(Vector3 inputPos)
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f, LayerMask.GetMask("SelectableObject")))
        {
            if (hit.collider != null)
            {
                _currentObject = hit.transform.GetComponentInParent<ISelectableObject>();

                _currentObject.Select(inputPos);
            }
        }
    }

    public void Drag(Vector3 inputPos)
    {
        if (_currentObject != null)
            _currentObject.Drag(inputPos);
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
