using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonSpawnArea : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    public Vector3 GetSpawnPoint()
    {
        SpawnPoint point = _spawnPoints.First(point => !point.IsFull);

        if(point == null)
            return Vector3.zero;

        return point.transform.position;
    }
}
