using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource punchAudio,  kickAudio;
    
    
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
        

        yield return new WaitForSeconds(1f);
        punchAudio.Play();
        yield return new WaitForSeconds(1f);
        
        anim.SetBool("isPunching2", false);
    }
    
    
    IEnumerator Bash()
    {
        anim.SetBool("isPunching1", true);
        

        yield return new WaitForSeconds(0.7f);
        punchAudio.Play();
        yield return new WaitForSeconds(0.7f);
        
        anim.SetBool("isPunching1", false);
    }
    
    
    IEnumerator Kick()
    {
        anim.SetBool("isKicking", true);
        

        yield return new WaitForSeconds(0.7f);
        kickAudio.Play();
        yield return new WaitForSeconds(0.7f);
        
        anim.SetBool("isKicking", false);
    }

}
