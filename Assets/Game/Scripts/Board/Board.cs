using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private BoardGrid _grid;

    public void Initialize()
    {
        _grid.Initialize();
    }
}
