using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    [SerializeField] private BaseFlag _baseFlag;
    [SerializeField] private int _maxUnitCount;
    [SerializeField] private UnitsSpawner _unitsSpawner;
    [SerializeField] private ResourceScanner _scanner;
    [SerializeField] private BaseMoneySystem _moneySystem;
    [SerializeField] private BaseResourceHandler _baseResourceHandler;
    [SerializeField] private float _delay;

    private List<Unit> _units = new List<Unit>();
    private float _time;
    private bool _isTouch = false;
    private bool _canBuildBase = false;


    private void OnEnable()
    {
        _unitsSpawner.UnitSpawned += OnUnitSpawned;
        _scanner.ResourceCellFound += OnResourceCellFound;
        _baseResourceHandler.ResourceSent += OnResourceSent;
        _moneySystem.UnitAccumulated += OnUnitAccumulated;
        _moneySystem.BaseAccumulated += OnBaseAccumulated;

    }

    private void OnDisable()
    {
        _unitsSpawner.UnitSpawned -= OnUnitSpawned;
        _scanner.ResourceCellFound -= OnResourceCellFound;
        _baseResourceHandler.ResourceSent -= OnResourceSent;
        _moneySystem.UnitAccumulated -= OnUnitAccumulated;
        _moneySystem.BaseAccumulated -= OnBaseAccumulated;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _delay)
        {
            _scanner.Scan();
            _time = 0;
        }
    }

    public void AddUnit(Unit unit)
    {
        _units.Add(unit);
    }

    public void SetIsTouched()
    {
        _isTouch = !_isTouch;
    }

    public void MoveFlag(Vector3 newPosition)
    {
        if (!_isTouch)
        {
            return;
        }

        _baseFlag.MovePosition(newPosition);
    }

    private void OnBaseAccumulated()
    {
        _canBuildBase = true;
    }

    private void OnResourceCellFound(ResourceCell cell)
    {
        foreach (var unit in _units)
        {
            if (!unit.IsBusy)
            {
                if (_canBuildBase && _baseFlag.gameObject.activeSelf&&!_baseFlag.IsReserve)
                {
                    _baseFlag.Reserve();
                    unit.BuildBase(_baseFlag.transform);
                    _units.Remove(unit);
                    return;
                }

                cell.Reserve();
                unit.Mine(cell);
                return;
            }
        }
    }

    private void OnUnitSpawned(Unit unit)
    {
        unit.Init(this);
        AddUnit(unit);
    }


    private void OnResourceSent()
    {
        _moneySystem.AddResource();

        if (!_baseFlag.gameObject.activeSelf)//почему то выбивает на ошибку тут 
        {
            _moneySystem.BuyUnit();
        }
        else
        {
            _moneySystem.BuyBase();
        }
    }

    private void OnUnitAccumulated()
    {
        if (_units.Count < _maxUnitCount)
            _unitsSpawner.SpawnUnit();
    }
}
