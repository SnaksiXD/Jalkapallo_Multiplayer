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
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

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
        controller.Move(move * moveSpeed * Time.deltaTime);
    }


}
