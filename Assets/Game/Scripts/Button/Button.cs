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

    private Vector3 _defaultPosition;
    private Vector3 _dropPosition;
    private bool _onMergeArea;

    public bool OnMergeArea => _onMergeArea;

    public GameEnums.ButtonTypes CurrentType => _currentType;

    public Vector3 DropPosition
    {
        get => _dropPosition;
        set => _dropPosition = value;
    }

    public override void SetActive()
    {
        Initialize();
        base.SetActive();
    }
    public void Initialize()
    {
        _currentType = GameEnums.ButtonTypes.One;
        _defaultPosition = transform.position;
        _body.Initialize(CurrentType);
    }

    public void IncreaseBody()
    {
        _currentType++;
        _defaultPosition = _dropPosition;
        transform.DOMoveY(0f, .1f);
        _body.IncreaseBody(CurrentType);
    }

    public void ReturnDefaultPosition()
    {
        transform.DOMove(_defaultPosition, .3f);
    }

    public void EnterSpawnPointBehaviour(Vector3 pos)
    {
        _onMergeArea = true;
        pos.y = 0f;
        _dropPosition = pos;
    }
    public void ExitSpawnPointBehaviour()
    {
        _onMergeArea = false;
        _dropPosition = _defaultPosition;
    }

    public List<Vector3> GetBodyPositions()
    {
        _body.SetBodyPositions();
        return _body.BodyPositions;
    }

    #region ISelectable
    public void Select()
    {
        _defaultPosition = transform.position;
        _dropPosition = _defaultPosition;
        transform.DOMoveY(transform.position.y + _yAxisSelectionOffset, .3f);
    }
    public void Drag(Vector3 inputPos)
    {
        inputPos.y = transform.position.y;
        transform.position = inputPos;
    }

    public void Drop()
    {
        if (!_onMergeArea)
            CheckBoardAreaHandler.Instance.CheckBoardArea(this);
        
        transform.DOMove(_dropPosition, .3f);
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
