using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed at which the player moves
    [SerializeField] private float jumpForce = 5f; // Force applied when jumping
    [SerializeField] private float groundCheckDistance = 1f; // Distance to check if the player is grounded
    [SerializeField] private float coyoteTime = 0.2f; // Time window after leaving the ground where the player can still jump
    [SerializeField] private LayerMask groundLayer; // Layer mask to determine what is considered ground
    [SerializeField] float rotationSmoothTime; 
    float currentAngle; 
    float currentAngleVelocity;

    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Flag indicating if the player is grounded
    private bool isJumping; // Flag indicating if the player is currently jumping
    private int maxJumpCount = 2; // Maximum number of jumps allowed
    [SerializeField] private int jumpCount; // Current jump count
    private bool jumpRequest = false; // Flag indicating if a jump has been requested
    private Vector3 moveDirection; // Direction of player movement 
    CharacterController controller;
    Camera cam;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Get the reference to the Rigidbody component
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Get horizontal input
        float verticalInput = Input.GetAxisRaw("Vertical"); // Get vertical input
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized; // Normalize the input to get movement direction

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true; // Set jump request flag when Space key is pressed
        }
        if (isGrounded)
        {
            jumpCount = 0; // Reset jump count when grounded
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer); // Check if the player is grounded using a raycast
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red); // Draw a debug ray to visualize the ground check

        if (jumpRequest)
        {
            if (isGrounded || jumpCount < maxJumpCount)
            {
                isJumping = true; // Set jumping flag if jump is allowed
            }
            jumpRequest = false; // Reset jump request flag
        }

        if (isJumping)
        {
            jumpCount++; // Increment jump count
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Apply jump force
            isJumping = false; // Reset jumping flag
        }

        // Apply movement force to the Rigidbody
        if (moveDirection.magnitude >= 0.1f)
        {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        Quaternion smoothedRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSmoothTime * Time.deltaTime);
        rb.MoveRotation(smoothedRotation);
        Vector3 rotatedMovement = smoothedRotation * Vector3.forward;
        rb.MovePosition(rb.position + rotatedMovement * moveSpeed * Time.deltaTime);
        }
    }
}