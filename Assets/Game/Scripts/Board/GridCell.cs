using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : PoolObject
{
    private bool _isPlaceable;

    public bool IsPlaceable => _isPlaceable;

    public void Initialize()
    {
        _isPlaceable = true;
    }

    public void TriggerEnterBehaviour(Collider other)
    {
        _isPlaceable = false;
    }
    public void TriggerExitBehaviour(Collider other)
    {
        _isPlaceable = true;
    }
}
