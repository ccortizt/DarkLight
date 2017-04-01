using System;
using System.Collections;
using UnityEngine;
public class PlayerMotor: MonoBehaviour{

    private CharacterController controller;

    private float verticalVelocity;
    private float gravity =  14.0f;
    private float jumpForce = 5.5f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    private void Update(){
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = verticalVelocity;
        moveVector.z = 0;
        controller.Move(moveVector * Time.deltaTime);
    }
}