using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _movementVector;

    private void ButtonPressReader()
    {
        _movementVector.x = Input.GetAxis("Horizontal");
        _movementVector.z = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        ButtonPressReader();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector3(_movementVector.x,_movementVector.y,_movementVector.z) * _speed * Time.fixedDeltaTime);
    }

}
