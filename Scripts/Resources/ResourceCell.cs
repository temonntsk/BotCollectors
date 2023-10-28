using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCell : MonoBehaviour
{
    private Resource _resource;

    public bool IsEmpty => _resource == null;

    public bool IsReserve;

    public void SetResource(Resource resource)
    {
        _resource = resource;
    }

    public Resource GetResource()
    {
        Resource resource = _resource;
        _resource = null;

        return resource;
    }

    public void Reserve() => IsReserve = true;

    public void Clear()
    {
        IsReserve = false;
        _resource = null;
    }
}
