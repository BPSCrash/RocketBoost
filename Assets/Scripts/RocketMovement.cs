using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float _thurstSpeed = 100;
    [SerializeField] private float _rotationSpeed = 100;
    private Rigidbody _rigidbody;

    public
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Rotate()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            ApplyRotation(_rotationSpeed);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            ApplyRotation(-_rotationSpeed);
        }
    }

    void Boost()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            _rigidbody.AddRelativeForce(Vector3.up * _thurstSpeed * Time.deltaTime);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }

    void FixedUpdate()
    {
        Rotate();
        Boost();
    }
}
