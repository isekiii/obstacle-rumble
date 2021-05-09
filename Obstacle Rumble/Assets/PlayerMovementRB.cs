using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementRB : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float movementSpeed, turnSmoothTime;

    [SerializeField] private float gravity, jumpHeight, hitForce;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private AudioSource jumpAudio;

    private float horizontal, vertical;
    private Rigidbody player;
    private bool isRunning;
    
    private float turnSmooth;

    private Vector2 moveDir;

    private Transform camTransform;

    public bool isGrounded;

    private bool isJumping = false;

    private Vector3 velocity;
    private Vector2 inputDir;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        velocity.y = Mathf.Clamp(velocity.y, -200, 3);
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.05f, layerMask);

        inputDir = new Vector2(horizontal, vertical);
        moveDir = inputDir.normalized;
        isRunning = moveDir.magnitude > 0;

        
        if (!anim.GetBool("isKicking") && !anim.GetBool("isPunching2") && !anim.GetBool("isPunching1"))
        {
            
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(Jump());
            }
        }
        else
        {
            horizontal = 0;
            vertical = 0;
        }
        
    }

    void FixedUpdate()
    {
        Animate(inputDir.y, inputDir.x);
        Rotate();
        Fall();
        Roll();
        Move();
    }

    void Move()
    {
        player.MovePosition(transform.position + transform.forward * movementSpeed * moveDir.magnitude * Time.deltaTime);
        
       // player.MovePosition(transform.position + velocity * Time.deltaTime);
     //  player.AddForce(velocity * Time.deltaTime , ForceMode.VelocityChange);
    }
    
    void Rotate()
    {
        if (moveDir!= Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(moveDir.x, moveDir.y)
                * Mathf.Rad2Deg + camTransform.eulerAngles.y;

            transform.eulerAngles = Vector3.up *
                                    Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, 
                                        ref turnSmooth,turnSmoothTime);
        }
    }
    
    
    IEnumerator Jump()
    {
        if (isGrounded && isRunning && !isJumping )
        {
            anim.Play("Jump");
            jumpAudio.Play();
           // velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight) * Time.deltaTime;
           player.AddForce(transform.up * Mathf.Sqrt(2 * gravity * jumpHeight) * Time.deltaTime, ForceMode.VelocityChange);
            isJumping = true;
        }

        yield return new WaitForSeconds(1f);
        isJumping = false;
    }
    

    void Fall()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
            anim.SetBool("isFalling", false);
        }
        else  velocity.y += -gravity * Time.deltaTime;
    }

    void Animate(float vertical, float horizontal)
    {
        if (vertical > 0 || horizontal > 0)
        {
            anim.SetFloat("Speed", 1f, 0.05f, Time.deltaTime);
        }
        else if (vertical < 0 || horizontal < 0)
        {
            anim.SetFloat("Speed", 1f, 0.05f, Time.deltaTime);
        }
        else anim.SetFloat("Speed", 0f, 0.05f, Time.deltaTime);

        if (velocity.y < -3 && !isGrounded)
        {
            anim.SetBool("isFalling", true);
        }
    }

    void Roll()
    {
        if (isRunning && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(RollAnim());
        }
    }
    
    
    IEnumerator RollAnim()
    {
        anim.SetBool("isRolling", true);
        var collider = this.GetComponent<CapsuleCollider>();
        collider.height /= 2;
        collider.center /= 2; 

        yield return new WaitForSeconds(1f);
        
        anim.SetBool("isRolling", false);
        collider.height *= 2;
        collider.center *= 2; 
    }

   

    


    public void GetHit(Vector3 dir )
    {
        player.AddForce(dir * hitForce * Time.deltaTime, ForceMode.VelocityChange);
    }
}
