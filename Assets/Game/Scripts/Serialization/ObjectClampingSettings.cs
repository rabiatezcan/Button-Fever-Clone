using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Button Fever/Object Clamp Settings", order = 2)]

public class ObjectClampingSettings : ScriptableObject
{
    [Header("Movement Parameters")]
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY; 
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxZ;

    public float MinX => _minX;
    public float MaxX => _maxX; 
    public float MinY => _minY;
    public float MaxY => _maxY;  
    public float MinZ => _minZ;
    public float MaxZ => _maxZ;
}
