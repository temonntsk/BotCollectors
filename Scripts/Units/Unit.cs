using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitMover _mover;
    [SerializeField] private UnitCollector _collector;
    [SerializeField] private UnitBaseBuilder _builder;

    private Base _base;

    public bool IsBusy { get; private set; }

    private void OnEnable()
    {
        _collector.ResourceCollected += OnResourceCollected;
        _collector.ResourceSent += OnResourceSent;
        _builder.BaseBuilt += OnBaseBuild;
    }

    private void OnDisable()
    {
        _collector.ResourceCollected -= OnResourceCollected;
        _collector.ResourceSent -= OnResourceSent;
        _builder.BaseBuilt -= OnBaseBuild;
    }

    public void Init(Base currentBase)
    {
        _base = currentBase;
    }

    public void Mine(ResourceCell resourceCell)
    {
        IsBusy = true;
        _mover.SetTarget(resourceCell.transform);
        _collector.SetResourceCell(resourceCell);
    }

    public void BuildBase(BaseFlag flag)
    {
        IsBusy = true;
        _mover.SetTarget(flag.transform);
        _builder.SetFlagPosition(flag);
    }

    private void OnResourceCollected(Resource resource) => MoveToBase();

    private void OnResourceSent()
    {
        IsBusy = false;
    }

    private void OnBaseBuild(Base newBase)
    {
        _base = newBase;
        newBase.AddUnit(this);
        IsBusy = false;
    }


    private void MoveToBase()
    {
        _mover.SetTarget(_base.transform);
    }
}
