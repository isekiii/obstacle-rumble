using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Cubescript : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    

    
    void Update()
    {
        if (player.transform.position.z - gameObject.transform.position.z <= 27)
        {
            anim.SetBool("1",true);
        }
    }
}
