using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAIPlayer : MonoBehaviour
{
    Transform player;
    EnemyMovementAI enemy;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerBody").GetComponent<Transform>();
        enemy = GameObject.FindWithTag("EnemyBody").GetComponent<EnemyMovementAI>();
    }

    private void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            enemy.GetHit(player.transform.forward);
        }
        if (other.gameObject.tag == "Enemy")
        {
            enemy.GetHit(player.transform.forward);
        }
        
    }
}
