using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    ParticleSystem _system;
    private void Start()
    {
        _system = GetComponentInChildren<ParticleSystem>();
    }
    public void ToggleParticles(bool shouldEmit)
    {
        if (shouldEmit)
        {
            _system.Play();
        }
        else
        {
            _system.Stop();
        }

    }
}
