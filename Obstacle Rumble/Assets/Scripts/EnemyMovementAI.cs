using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioSource getHitAudio;
    [SerializeField] private AudioSource punchAudio,  kickAudio;
    private Animator anim;
    public float hitForce = 300;

    private Rigidbody rb;
    private bool beingHit;
    public bool isGrounded;
    public float gravity = 9.8f;
    private Random random = new Random();


    private void Start()
    {
        beingHit = false;
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        agent.updateRotation = true;
    }


    private void FixedUpdate () {
       // rb.Mo
       isGrounded = Physics.CheckSphere(groundCheck.position, 1f, layerMask);
       
       if (!beingHit && isGrounded && !anim.GetBool("gotHit"))
       {
           RotateTowards(player);
           if (Vector3.Distance(agent.transform.position, player.position) <= 1)
           {
               Attack();
               
           }
           else agent.SetDestination(player.position);
       }

       if (!isGrounded)
       {
           agent.enabled = false;
           rb.MovePosition(transform.position + transform.up * -1 * gravity * Time.deltaTime);
       }
       else if (!beingHit && anim.GetBool("gotHit"))
       {
           agent.enabled = true;
       }
    }

    public void Attack()
    {
        int nr = random.Next(1, 3);
        if (nr == 1 && !anim.GetBool("isPunching1") && !anim.GetBool("isPunching2") && !anim.GetBool("isKicking")) StartCoroutine(Bash());
        else if (nr == 2 && !anim.GetBool("isPunching1") && !anim.GetBool("isPunching2") && !anim.GetBool("isKicking")) StartCoroutine(UpperCut());
        else if (nr == 3 && !anim.GetBool("isPunching1") && !anim.GetBool("isPunching2") && !anim.GetBool("isKicking")) StartCoroutine(Kick());
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "PlayerLimb" )
        {
            Debug.Log("Player hit AI");
          // rb.AddForce(-1 * transform.forward * 500000 * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void RotateTowards (Transform target) {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
    }
    
    public void GetHit(Vector3 dir )
    {
        StartCoroutine(gotHit(dir));
    }

    IEnumerator gotHit(Vector3 dir)
    {
        agent.enabled = false;
        rb.isKinematic = false;
        beingHit = true;
        anim.SetBool("gotHit", true);
        getHitAudio.Play();
        rb.AddForce(dir * hitForce * Time.deltaTime, ForceMode.VelocityChange);
        yield return new WaitForSeconds(4.6f);
        anim.SetBool("gotHit", false);
        rb.isKinematic = true;
        agent.enabled = true;
        beingHit = false;
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
