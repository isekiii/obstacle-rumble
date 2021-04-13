using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CubeStuff : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] cubes;

    
    //[SerializeField] private AnimationClip[] animations;
    

    private void Update()
    {
        
        for (int i = 0; i < cubes.Length; i++)
        {
            Debug.Log(player.transform.position.z - cubes[i].transform.position.z);
            if (player.transform.position.z - cubes[i].transform.position.z <= 30)
            {
                anim.SetBool($"{i}", true);
            }
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Start", true);
        }
    }
}
