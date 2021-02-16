using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private CharacterController player;

    [SerializeField] private Animator anim;

    [SerializeField] private float movementSpeed, turnSmoothTime;

    private float turnSmooth;



    private Vector2 moveDir;

    private Transform camTransform;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        var inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDir = inputDir.normalized;

        Move();
        Animate(inputDir.y, inputDir.x);
        Rotate();
    }

    void Move()
    {
        player.Move(transform.forward * movementSpeed * moveDir.magnitude * Time.deltaTime);
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

