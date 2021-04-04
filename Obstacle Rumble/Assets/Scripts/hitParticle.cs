using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem hit;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player")) return;
        hit.Play();
    }
}
