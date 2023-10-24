using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitMovement))]
public class Unit : MonoBehaviour
{ 
    private UnitMovement _unitMovement;
    private Resource _resourceTaken;

    private void Awake()
    {
        _unitMovement = GetComponent<UnitMovement>();
    }

    public bool IsMoving()
    {
        return _unitMovement.IsMoving;
    }

    public void NavigateToAndFromResource(Resource resource, DropOffPoint dropOffPoint)
    {
        _unitMovement.SetPositionToResource(resource);
        _unitMovement.SetPositionToBase(dropOffPoint);
    }
}
