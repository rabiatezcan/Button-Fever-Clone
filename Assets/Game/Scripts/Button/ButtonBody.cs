using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBody : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bodies; 
    public void Initialize(GameEnums.ButtonTypes bodyType)
    {
        HideAllBodies();
        ShowBody(bodyType);
    }

    private void ShowBody(GameEnums.ButtonTypes bodyType)
    {
        _bodies[((int)bodyType)].SetActive(true);
    }

    private void HideAllBodies()
    {
        _bodies.ForEach(body => body.SetActive(false));
    }
}
