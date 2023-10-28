using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoneySystem : MonoBehaviour
{
    [SerializeField] private int _unitPrice;
    [SerializeField] private int _basePrice;

    public int ResourcesCount { get; private set; }
    public bool CanCreateUnit => ResourcesCount >= _unitPrice;
    public bool CanCreateBase => ResourcesCount >= _basePrice;

    public event Action UnitAccumulated;
    public event Action BaseAccumulated;

    public void AddResource()
    {
        ResourcesCount++;
    }

    public void BuyBase()
    {
        if (CanCreateBase)
        {
            ResourcesCount -= _basePrice;
            BaseAccumulated?.Invoke();
        }
    }

    public void BuyUnit()
    {
        if (CanCreateUnit)
        {
            ResourcesCount -= _unitPrice;
            UnitAccumulated?.Invoke();
        }
    }

    public void RemoveResource()
    {
        ResourcesCount--;
    }
}
