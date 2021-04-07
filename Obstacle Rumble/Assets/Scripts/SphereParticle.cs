using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem sparkle;

    private void OnCollisionEnter(Collision other)
    {
        sparkle.Play();
    }
}
