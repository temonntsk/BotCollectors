using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        if (_target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target.position);
    }
}
