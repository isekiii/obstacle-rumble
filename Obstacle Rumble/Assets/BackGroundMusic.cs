using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music1, music2, music3;
    [SerializeField] private AudioSource audio;


    private void Start()
    {
        StartCoroutine(PlayMusic());
    }

    


    IEnumerator PlayMusic()
    {
        audio.Stop();
        audio.clip = music1;
        audio.Play();
        yield return new WaitForSeconds(90f); // music1
        audio.Stop();
        audio.clip = music2;
        audio.Play();
        yield return new WaitForSeconds(82f); // music2
        audio.Stop();
        audio.clip = music3;
        audio.Play();
        yield return new WaitForSeconds(121f); // music3
        StartCoroutine(PlayMusic());

    }
}
