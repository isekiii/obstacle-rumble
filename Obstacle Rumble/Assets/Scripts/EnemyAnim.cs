using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private float minSpeed, maxSpeed, acceleration;

    private bool isRunning;
    
    void Update()
    {
        RunAnimation();
        isRunning = anim.GetFloat("Speed") > 0;
        agent.speed = Mathf.Clamp(agent.speed, minSpeed, maxSpeed);
        Accelerate();

    }


    void Accelerate()
    {
        if (isRunning)
        {
            agent.speed += acceleration * Time.deltaTime;
        }
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
