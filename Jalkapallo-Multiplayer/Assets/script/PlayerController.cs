using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    CharacterController controller;

    public float moveSpeed = 8f;

    public float runSpeed = 14f;

    public float jumpheight = 3f;

    public float gravity = -9.81f;

    public Vector3 velocity;

    public Transform groundCheck;

    public float groundDistance = 0.1f;

    public LayerMask groundMask;

    public Animator animator;

    [SerializeField] private bool isGrounded;

    private Vector3 move;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        Move();
        Jump();
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        animator.SetBool("Grounded", isGrounded);

        if(isGrounded)
        {
            velocity.y = -2;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");


        move = transform.right * xAxis + transform.forward * zAxis;

        float targetSpeed = Input.GetButton("Fire1") ? runSpeed : moveSpeed;

        

        if(move == Vector3.zero)
        {
            targetSpeed = 0;
        }
        
        animator.SetFloat("Speed", targetSpeed);

        controller.Move(move * targetSpeed * Time.deltaTime);
    }
    
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


}
