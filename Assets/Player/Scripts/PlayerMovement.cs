using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentSpeed = 5f;
    public float walkSpeed = 5f;
    public float strafeSpeed = 4f;
    public float backwardsSpeed = 3f;
    public float crouchSpeed = 2f;
    public float runSpeed = 8f;

    bool isStrafing;
    bool isRunning;
    bool isBackwards;
    bool isWalking;

    Vector3 move;

    public CharacterController controller;

    float xInput;
    float zInput;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    bool isGrounded;

    public Vector3 playerVelocity;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        move = transform.right * xInput + transform.forward * zInput;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }


        float forwardsAmount = Vector3.Dot(transform.forward, move);
        if (forwardsAmount < -.5f)
        {
            currentSpeed = backwardsSpeed;
        }
        else if (forwardsAmount < .5f)
        {
            currentSpeed = strafeSpeed;
        }
        else if (forwardsAmount < 0)
        {
            currentSpeed = walkSpeed;
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        playerVelocity.y += gravity * Time.deltaTime;


        controller.Move(move * currentSpeed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
