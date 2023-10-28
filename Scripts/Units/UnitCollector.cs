using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

public class UnitCollector : MonoBehaviour
{
    [SerializeField] private ResourceTrigger _trigger;

    private Resource _resource;
    private ResourceCell _resourceCell;

    public bool IsEmpty=> _resource == null;

    public event Action<Resource> ResourceCollected;
    public event Action ResourceSent;

    private void OnEnable()
    {
        _trigger.ResourceCellFound += OnResourceCellFound;
    }

    public void SetResourceCell(ResourceCell resourceCell)
    {
        _resourceCell = resourceCell;
    }

    public void ClearStorage()
    {
        Destroy(_resource.gameObject);
        _resource = null;
        _resourceCell.Clear();
        ResourceSent?.Invoke();
    }

    private void OnResourceCellFound(ResourceCell cell)
    {
        if (cell == _resourceCell)
        {
            _resource = cell.GetResource();
            _resource.transform.SetParent(transform, true);
            ResourceCollected?.Invoke(_resource);
        }
    }
}
