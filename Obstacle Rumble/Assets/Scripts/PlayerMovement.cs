using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private CharacterController player;

    [SerializeField] private Animator anim;

    [SerializeField] private float movementSpeed, turnSmoothTime;

    [SerializeField] private float gravity, jumpHeight;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask layerMask;

    private bool isRunning;
    
    private float turnSmooth;

    private Vector2 moveDir;

    private Transform camTransform;

    public bool isGrounded;

    public bool isJumping = false;

    private Vector3 velocity;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.05f, layerMask);
        
        var inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDir = inputDir.normalized;

        isRunning = moveDir.magnitude > 0;

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jump());
        }
        
        Animate(inputDir.y, inputDir.x);
        Rotate();
        Fall();
        Move();
    }

    void Move()
    {
        player.Move(transform.forward * movementSpeed * moveDir.magnitude * Time.deltaTime);
        player.Move(velocity * Time.deltaTime);
    }

    
    IEnumerator Jump()
    {
        if (isGrounded && isRunning && !isJumping)
        {
            anim.Play("Jump");
              
            velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight) * Time.deltaTime;
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


}

