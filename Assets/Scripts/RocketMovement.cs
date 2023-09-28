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
    private ParticlesController _particlesController;
    private SoundController _soundController;

    public
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _particlesController = GetComponent<ParticlesController>();
        _soundController = GetComponent<SoundController>(); 
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
            EmitParticles();
        } 
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        _rigidbody.freezeRotation = false;
    }

    private void EmitParticles()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            _particlesController.ToggleParticles(shouldEmit: true);

        }
        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            _particlesController.ToggleParticles(shouldEmit: false);
        }
    }

    private void PlaySound()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            _soundController.ToggleAudio(shouldEmit: true);

        }
        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            _soundController.ToggleAudio(shouldEmit: false);
        }
    }

    void FixedUpdate()
    {
        Rotate();
        Boost();
    }

    private void Update()
    {
        EmitParticles();
        PlaySound();
    }
}
