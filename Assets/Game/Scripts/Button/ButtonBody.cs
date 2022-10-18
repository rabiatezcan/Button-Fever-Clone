using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonBody : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bodies;
    [SerializeField] private TextMeshPro _valueTxt;

    private List<Vector3> _bodyPartPositions;

    private GameEnums.ButtonTypes _currentBody;

    public List<Vector3> BodyPositions => _bodyPartPositions;
    public void Initialize(GameEnums.ButtonTypes bodyType)
    {
        _currentBody = bodyType;
        _bodyPartPositions = new List<Vector3>();
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
    public void SetBodyPositions()
    {
        _bodyPartPositions.Clear(); 

        switch (_currentBody)
        {
            case GameEnums.ButtonTypes.One:
                _bodyPartPositions.Add(_bodies[0].transform.position);
                break;

            case GameEnums.ButtonTypes.Two:
                _bodyPartPositions.Add(_bodies[1].transform.position + (Vector3.right * .75f));
                _bodyPartPositions.Add(_bodies[1].transform.position + (Vector3.left * .75f));
                break;

            case GameEnums.ButtonTypes.Four:
                _bodyPartPositions.Add(_bodies[2].transform.position + (Vector3.right * 1.5f));
                _bodyPartPositions.Add(_bodies[2].transform.position + (Vector3.left * 1.5f));
                _bodyPartPositions.Add(_bodies[2].transform.position);
                break;

            case GameEnums.ButtonTypes.Eight:
                _bodyPartPositions.Add(_bodies[3].transform.position + new Vector3(-.75f, 0f, -.75f));
                _bodyPartPositions.Add(_bodies[3].transform.position + new Vector3(.75f, 0f, -.75f));
                _bodyPartPositions.Add(_bodies[3].transform.position + new Vector3(.75f, 0f, .75f));
                break;
        }
    }
}
