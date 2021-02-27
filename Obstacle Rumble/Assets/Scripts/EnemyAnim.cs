using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    void Update()
    {
        RunAnimation();
    }


    void RunAnimation()
    {
        Vector2 axis = new Vector2(agent.velocity.x, agent.velocity.z);
        float horizontal = agent.velocity.x;
        float vertical = agent.velocity.z;
        
        if (vertical > 0 || horizontal > 0)
        {
            anim.SetFloat("Speed", 1f, 0.05f, Time.deltaTime);
        }
        else if (vertical < 0 || horizontal < 0)
        {
            anim.SetFloat("Speed", 1f, 0.05f, Time.deltaTime);
        }
        else anim.SetFloat("Speed", 0f, 0.05f, Time.deltaTime);

        if (agent.velocity.y < -3 )
        {
            anim.SetBool("isFalling", true);
        }
    }
    
}
