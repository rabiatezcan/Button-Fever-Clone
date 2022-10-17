using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonBody : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bodies;
    [SerializeField] private TextMeshPro _valueTxt;

    private GameEnums.ButtonTypes _currentBody;
    public void Initialize(GameEnums.ButtonTypes bodyType)
    {
        _currentBody = bodyType;
        SetBody();
    }

    public void IncreaseBody(GameEnums.ButtonTypes bodyType)
    {
        _currentBody = bodyType;
        IncreaseBodyAnimation();
        SetBody();
    }
    private void IncreaseBodyAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(1.2f, .25f))
                .Append(transform.DOScale(1f, .25f));
    }
    private void SetBody()
    {
        HideAllBodies();
        ShowBody();
        SetValueTxt();
    }

    private void SetValueTxt()
    {
        _valueTxt.text = "+" + GetBodyValue(((int)_currentBody));
    }
    private void ShowBody()
    {
        _bodies[((int)_currentBody)].SetActive(true);
    }

    private void HideAllBodies()
    {
        _bodies.ForEach(body => body.SetActive(false));
    }

    private int GetBodyValue(int value)
    {
        return ((int)Mathf.Pow(2, value));
    }
}
