using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitsSpawner : MonoBehaviour
{
    [SerializeField] private Unit _prefab;
    [SerializeField] private int _startCountUnit;

    public event Action<Unit> UnitSpawned;

    private void Start()
    {
        for (int i = 0; i < _startCountUnit; i++)
        {
            SpawnUnit();
        }
    }

    public void SpawnUnit()
    {
        Unit newUnit = Instantiate(_prefab, transform.position, Quaternion.identity);
        UnitSpawned?.Invoke(newUnit);
    }
}
