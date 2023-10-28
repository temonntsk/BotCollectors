using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseResourceHandler : MonoBehaviour
{
    public event Action ResourceSent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out UnitCollector collector))
        {
            if (collector.IsEmpty == false)
            {
                collector.ClearStorage();
                 ResourceSent?.Invoke();
            }
        }
    }
}
