using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Button : PoolObject, ISelectableObject
{
    [SerializeField] private ButtonBody _body;
    [SerializeField] private ObjectClampingSettings _clampSettings;
    [SerializeField] private float _yAxisSelectionOffset;
    private GameEnums.ButtonTypes _currentType;

    private Vector3 _defaultPosition;
    private Vector3 _dropPosition;
    private bool _onMergeArea;

    public bool OnMergeArea => _onMergeArea;
    public GameEnums.ButtonTypes CurrentType
    {
        get => _currentType;
        set => _currentType = value;
    }
    public int ButtonValue => _body.GetBodyValue(((int)_currentType));
    public Vector3 DropPosition
    {
        get => _dropPosition;
        set => _dropPosition = value;
    }

    public override void SetActive()
    {
        PlayerHelper.Instance.AddButton(this);
        Initialize();
        base.SetActive();
    }

    public override void Dismiss()
    {
        PlayerHelper.Instance.RemoveButton(this);
        base.Dismiss();
    }

    public void Initialize()
    {
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

    public void Push()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(.3f, .25f))
                .Append(transform.DOMoveY(.5f, .25f));
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
        inputPos.x = Mathf.Clamp(inputPos.x, _clampSettings.MinX, _clampSettings.MaxX);
        inputPos.y = transform.position.y;
        inputPos.z = Mathf.Clamp(inputPos.z, _clampSettings.MinZ, _clampSettings.MaxZ);
        transform.position = inputPos;
    }

    public void Drop()
    {
        if (!_onMergeArea)
            CheckBoardAreaHandler.Instance.CheckBoardArea(this);

        transform.DOMove(_dropPosition, .3f);
        _defaultPosition = _dropPosition;
    }
    #endregion


    #region Trigger Behaviour

    public void TriggerEnterBehaviour(Collider other)
    {
        MergeHandler.AddMergeElement(this);
    }
    #endregion
}
