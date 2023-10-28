using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private Collider[] _overLappedColliders = new Collider[50];

    public event Action<ResourceCell> ResourceCellFound;

    public void Scan()
    {
        Vector3 center = transform.position;
        Physics.OverlapSphereNonAlloc(center, _radius, _overLappedColliders, _layerMask);

        foreach (var collider in _overLappedColliders)
        {
            if (collider == null) 
            { 
                continue; 
            }

            if (collider.TryGetComponent(out ResourceCell resourceCell))
            {
                if (!resourceCell.IsEmpty && !resourceCell.IsReserve)
                {
                    ResourceCellFound?.Invoke(resourceCell);
                    return;
                }
            }
        }
    }
}
