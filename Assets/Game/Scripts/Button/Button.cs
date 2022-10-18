using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Button : PoolObject, ISelectableObject
{
    [SerializeField] private ButtonBody _body;
    [SerializeField] private float _yAxisSelectionOffset;
    private GameEnums.ButtonTypes _currentType;

    private Vector3 _selectionOffset;
    private bool _onMergeArea;

    public bool OnMergeArea 
    {
        get => _onMergeArea; 
        set => _onMergeArea = value;
    }
    public GameEnums.ButtonTypes CurrentType => _currentType;

    public override void SetActive()
    {
        Initialize();
        base.SetActive();
    }
    public void Initialize()
    {
        _currentType = GameEnums.ButtonTypes.One;
        _body.Initialize(CurrentType);
    }

    public void IncreaseBody()
    {
        _currentType++;
        transform.DOMoveY(0f, .1f);
        _body.IncreaseBody(CurrentType);
    }

    #region ISelectable
    public void Select(Vector3 inputPos)
    {
        transform.DOMoveY(transform.position.y + _yAxisSelectionOffset, .3f);
        _selectionOffset = transform.position - inputPos;
    }
    public void Drag(Vector3 inputPos)
    {
        Vector3 pos = inputPos + _selectionOffset;
        pos.y = _yAxisSelectionOffset;
        transform.DOMove(pos, .1f);
    }

    public void Drop()
    {
        transform.DOMoveY(0f, .3f);
    }


    #endregion


    #region Trigger Behaviour

    public void TriggerEnterBehaviour(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            MergeHandler.AddMergeElement(this);
        }
    }
    public void TriggerExitBehaviour(Collider other)
    {

    }
    #endregion
}
