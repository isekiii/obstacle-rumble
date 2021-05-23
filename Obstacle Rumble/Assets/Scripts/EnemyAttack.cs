using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerMovementRB player;
    EnemyMovementAI enemy;
    Animator anim;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerMovementRB>();
        anim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyMovementAI>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBody")
        {
            
            if (anim.GetBool("isPunching2") || anim.GetBool("isPunching1") || anim.GetBool("isKicking"))
            {
                player.GetHit(enemy.transform.forward);
            }  
        }
    }
}
