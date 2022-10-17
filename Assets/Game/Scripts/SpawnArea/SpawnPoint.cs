using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isFull;

    public bool IsFull => _isFull;

    public void TriggerEnterBehaviour()
    {
        _isFull = true;
    }
    public void TriggerExitBehaviour()
    {
        _isFull = false;
    }


}
