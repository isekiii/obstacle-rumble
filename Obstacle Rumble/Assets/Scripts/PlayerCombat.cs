using System;
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

          StartCoroutine(Kick());
        }

        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(UpperCut());
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Bash());
        }
  
    }

    IEnumerator UpperCut()
    {
        anim.SetBool("isPunching2", true);

        yield return new WaitForSeconds(2f);
        
        anim.SetBool("isPunching2", false);
    }
    
    
    IEnumerator Bash()
    {
        anim.SetBool("isPunching1", true);

        yield return new WaitForSeconds(1.4f);
        
        anim.SetBool("isPunching1", false);
    }
    
    
    IEnumerator Kick()
    {
        anim.SetBool("isKicking", true);

        yield return new WaitForSeconds(1.4f);
        
        anim.SetBool("isKicking", false);
    }

}
