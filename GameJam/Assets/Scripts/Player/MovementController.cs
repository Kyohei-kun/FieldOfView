using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;

    [Header("Player Physics Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckIsGrounded();
        DoJump();
        MovePlayer();
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += -gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void CheckIsGrounded()
    {
        if (controller.isGrounded)
        {
            velocity.y = -2f;
        }
    }

    private void DoJump()
    {
        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * -gravity);
        }
    }
}
