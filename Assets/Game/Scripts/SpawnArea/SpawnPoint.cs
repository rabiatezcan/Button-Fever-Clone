using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool _isFull;
    public bool IsFull => _isFull;

    public void TriggerEnterBehaviour(Collider other)
    {
        _isFull = true;
        var button = other.GetComponentInParent<Button>();
        button.EnterSpawnPointBehaviour(transform.position);
    }
    public void TriggerExitBehaviour(Collider other)
    {
        _isFull = false;
        var button = other.GetComponentInParent<Button>();
        button.ExitSpawnPointBehaviour();
    }
}
