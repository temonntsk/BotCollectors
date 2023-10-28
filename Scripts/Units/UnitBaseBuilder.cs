using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBaseBuilder : MonoBehaviour
{
    [SerializeField] private Base _base;

    private Transform _flagPosition;

    public event Action<Base> BaseBuilt;

    private void Update()
    {
        if (_flagPosition == null)
            return;

        if (transform.position == _flagPosition.position)
        {
            BuildBase(_flagPosition);
            _flagPosition = null;
        }
    }

    public void SetBuild(Transform flagPosition)
    {
        _flagPosition = flagPosition;
    }

    private void BuildBase(Transform flagPosition)
    {
        _flagPosition = flagPosition;
        Base newBase = Instantiate(_base, flagPosition.position, Quaternion.identity);
        BaseBuilt?.Invoke(newBase);
    }
}
