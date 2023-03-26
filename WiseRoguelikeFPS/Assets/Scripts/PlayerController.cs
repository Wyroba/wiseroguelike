using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 2f;
    public float gravity = -9.81f;
    private float cameraSens = 10.0f;
    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Rotate();


        PlayerAnimator();
        

    }

    private void Move()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 move = (transform.forward * vert + transform.right * horiz) * speed * Time.deltaTime;

        // Apply gravity
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        controller.Move(move);
    }

    private void Rotate()
    {
        float horizontalSpeed = 1.0f;
        float verticalSpeed = 1.0f;

        float horiz = horizontalSpeed * Input.GetAxis("Mouse X");
        float vert = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(-vert, horiz, 0);


    }

    private void PlayerAnimator()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            animator.SetBool("isWalkingForward", true);
            animator.SetBool("isWalkingBackward", false);
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);

        }
        else
        {
            animator.SetBool("isWalkingForward", false);

        }


        if (Input.GetKey(KeyCode.S) == true)
        {
            animator.SetBool("isWalkingBackward", true);
            animator.SetBool("isWalkingForward", false);
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
        }
        else
        {
            animator.SetBool("isWalkingBackward", false);

        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            animator.SetBool("isWalkingRight", true);
            animator.SetBool("isWalkingForward", false);
            animator.SetBool("isWalkingBackward", false);
            animator.SetBool("isWalkingLeft", false);

        }
        else
        {
            animator.SetBool("isWalkingRight", false);
        }

        if (Input.GetKey(KeyCode.A) == true)
        {
            animator.SetBool("isWalkingLeft", true);
            animator.SetBool("isWalkingForward", false);
            animator.SetBool("isWalkingBackward", false);
            animator.SetBool("isWalkingRight", false);
        }
        else
        {
            animator.SetBool("isWalkingLeft", false);
        }
    }

}
