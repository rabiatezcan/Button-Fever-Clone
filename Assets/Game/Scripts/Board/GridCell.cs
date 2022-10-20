using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : PoolObject
{
    private bool _isPlaceable;

    public bool IsPlaceable 
    { 
        get => _isPlaceable; 
        set => _isPlaceable = value; 
    }

    public void Initialize()
    {
        IsPlaceable = true;
    }

    public void TriggerEnterBehaviour(Collider other)
    {
        _isPlaceable = false;
    }
    public void TriggerExitBehaviour(Collider other)
    {
        IsPlaceable = true;
    }
}
