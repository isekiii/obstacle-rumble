﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
          // anim.SetTrigger("Kick");
          StartCoroutine(Kick());

        }
        
        Debug.Log(anim.GetBool("isKicking"));

        
        
    }

    bool isPlaying(string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else return false;
    }

    IEnumerator Kick()
    {
        anim.SetBool("isKicking", true);

        yield return new WaitForSeconds(1.4f);
        
        anim.SetBool("isKicking", false);
    }

}
