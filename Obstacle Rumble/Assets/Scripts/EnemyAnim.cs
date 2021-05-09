using UnityEngine;
using UnityEngine.AI;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;

    private bool isRunning;
    private bool isGrounded;
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, layerMask);
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

        if (!isGrounded && agent.velocity.y < -3 )
        {
            anim.SetBool("isFalling", true);
        }
    }
    
}
