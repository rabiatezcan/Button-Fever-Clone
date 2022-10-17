using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ButtonBody : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bodies;
    [SerializeField] private TextMeshPro _valueTxt;
    public void Initialize(GameEnums.ButtonTypes bodyType)
    {
        SetBody(bodyType);
    }
    private void SetBody(GameEnums.ButtonTypes bodyType)
    {
        HideAllBodies();
        ShowBody(bodyType);
        SetValueTxt(bodyType);
    }

    private void SetValueTxt(GameEnums.ButtonTypes value)
    {
        _valueTxt.text = "+" + GetBodyValue(value);
    }
    private void ShowBody(GameEnums.ButtonTypes bodyType)
    {
        _bodies[((int)bodyType)].SetActive(true);
    }

    private void HideAllBodies()
    {
        _bodies.ForEach(body => body.SetActive(false));
    }

    private int GetBodyValue(GameEnums.ButtonTypes value)
    {
        return (((int)value) * 2) + 1;
    }
}
