using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    PlayerMovementRB player;
    EnemyMovementAI enemy;
    Animator anim;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerMovementRB>();
        anim = GameObject.FindWithTag("PlayerBody").GetComponent<Animator>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyMovementAI>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            if (anim.GetBool("isPunching2") || anim.GetBool("isPunching1") || anim.GetBool("isKicking"))
            {
                enemy.GetHit(player.transform.forward);
            }
            
        }
    }
}
