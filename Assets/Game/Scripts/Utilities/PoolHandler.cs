using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    [SerializeField] private PoolManager _poolManager;

    private static PoolHandler _poolHandler;

    public static PoolHandler Instance
    {
        get
        {
            if (_poolHandler == null)
            {
                _poolHandler = new PoolHandler();
            }

            return _poolHandler;
        }
    }

    private void Awake()
    {
        _poolHandler = this;
    }

    public PoolObject GetItemFromPool(string poolName)
    {
        return _poolManager.GetItem(poolName);
    }
}
