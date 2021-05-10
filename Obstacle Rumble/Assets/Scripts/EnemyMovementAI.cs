using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioSource getHitAudio;
    public float hitForce = 300;

    private Rigidbody rb;
    private bool beingHit;
    public bool isGrounded;
    public float gravity = 9.8f;


    private void Start()
    {
        beingHit = false;
        rb = this.GetComponent<Rigidbody>();
    }


    private void FixedUpdate () {
       // rb.Mo
       isGrounded = Physics.CheckSphere(groundCheck.position, 1f, layerMask);
       
       if (!beingHit && isGrounded)
       {
           agent.SetDestination(player.position);
       }

       if (!isGrounded)
       {
           agent.enabled = false;
           rb.MovePosition(transform.position + transform.up * -1 * gravity * Time.deltaTime);
       }
       else if (!beingHit)
       {
           agent.enabled = true;
       }

       



    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "PlayerLimb" )
        {
            Debug.Log("Player hit AI");
          // rb.AddForce(-1 * transform.forward * 500000 * Time.deltaTime, ForceMode.VelocityChange);
        }
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
        getHitAudio.Play();
        rb.AddForce(dir * hitForce * Time.deltaTime, ForceMode.VelocityChange);
        yield return new WaitForSeconds(1.5f);
        rb.isKinematic = true;
        agent.enabled = true;
        beingHit = false;
    }
    
    
 
   
}
