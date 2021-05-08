using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem sparkle;
    [SerializeField] private AudioSource audio;

    private void OnCollisionEnter(Collision other)
    {
        sparkle.Play();
        audio.Play();
    }
}
