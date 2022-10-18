using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : PoolObject
{
    private bool _isPlaceable;

    public void Initialize()
    {
        _isPlaceable = true;
    }
}
