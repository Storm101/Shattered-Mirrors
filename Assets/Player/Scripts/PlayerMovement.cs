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

    Vector3 move;

    public CharacterController controller;

    float xInput;
    float zInput;

    float movement;

    void Update()
    {
        xInput = Input.GetAxis("Vertical");
        zInput = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * -xInput + transform.forward * zInput;

        controller.Move(move * currentSpeed * Time.deltaTime);


    }

    void FixedUpdate()
    {

    }
}
