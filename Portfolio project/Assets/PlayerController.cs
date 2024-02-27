using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float gravity = -40.0f;
    Vector3 moveDirection = Vector3.zero;
    private bool isJumping = false;
    private float jumpTime = 0.0f;
    private float maxJumpTime = 0.5f;



    void Start()
    {
    }


    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Always apply gravity
        moveDirection.y += gravity * Time.deltaTime;

        // Use SimpleMove for ground movement
        if (controller.isGrounded)
        {
            controller.SimpleMove(moveDirection);

            if (Input.GetButtonDown("Jump"))
            {
                jumpTime = maxJumpTime;
            }
        }

        if (jumpTime > 0)
        {
            // Apply the jump force over time
            moveDirection.y += jumpSpeed * Time.deltaTime;
            jumpTime -= Time.deltaTime;
        }

        // Apply the movement
        controller.Move(moveDirection * Time.deltaTime);
    }
}