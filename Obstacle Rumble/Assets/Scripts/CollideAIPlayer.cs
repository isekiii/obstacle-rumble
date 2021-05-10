using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAIPlayer : MonoBehaviour
{
    PlayerMovementRB player;
    EnemyMovementAI enemy;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerMovementRB>();
        enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyMovementAI>();
    }

    private void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            player.GetHit(player.transform.forward);
        }
        if (other.gameObject.tag == "Enemy")
        {
            enemy.GetHit(enemy.transform.forward);
        }
        
    }
}
