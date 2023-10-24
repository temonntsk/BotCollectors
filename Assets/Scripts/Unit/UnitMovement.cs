using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public bool IsMoving { get; private set; }

    private Resource _currentTargetResource;
    private Vector3 _currentTarget;
    private Vector3 _dropOffPoint;

    private void Update()
    {
        Move();
    }

    public void SetPositionToResource(Resource resource)
    {
        IsMoving = true;
        _currentTargetResource = resource;
        _currentTarget = _currentTargetResource.transform.position;
    }
    public void SetPositionToBase(DropOffPoint dropOffPoint)
    {
        _dropOffPoint = dropOffPoint.transform.position;
    }

    private Vector3 GetPosition()
    {
        if (IsMoving)
        {
            if (transform.position == _currentTarget)
            {
                ResourceCommunication();
            }

            return Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
        }
        else
            return transform.position;
    }

    private void Move()
    {
        transform.position = GetPosition();
        transform.LookAt(_currentTarget);
    }

    private void TakeResource()
    {
        _currentTargetResource.transform.SetParent(transform, true);

        _currentTarget = _dropOffPoint;
    }

    private void GiveResource()
    {
        _currentTargetResource.transform.SetParent(null);
        IsMoving = false;
    }

    private void ResourceCommunication()
    {
        TakeResource();

        if(transform.position == _dropOffPoint)
        {
            GiveResource();
        }
    }
}
