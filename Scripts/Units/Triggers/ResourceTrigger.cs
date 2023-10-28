using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceTrigger : MonoBehaviour
{
    public event Action<ResourceCell> ResourceCellFound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ResourceCell resource))
        {
            ResourceCellFound?.Invoke(resource);
        }
    }
}
