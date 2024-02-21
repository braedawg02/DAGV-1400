using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed at which the player moves
    [SerializeField] private float acceleration = 10f; // Acceleration when moving
    [SerializeField] private float deceleration = 10f; // Deceleration when stopping
    [SerializeField] private float jumpForce = 5f; // Force applied when jumping
    [SerializeField] private float groundCheckDistance = 1f; // Distance to check if the player is grounded
    [SerializeField] private float coyoteTime = 0.2f; // Time window after leaving the ground where the player can still jump
    [SerializeField] private LayerMask groundLayer; // Layer mask to determine what is considered ground

    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Flag indicating if the player is grounded
    private bool isJumping; // Flag indicating if the player is currently jumping
    private int maxJumpCount = 2; // Maximum number of jumps allowed
    private int jumpCount; // Current jump count
    private bool jumpRequest = false; // Flag indicating if a jump has been requested
    private Vector3 moveDirection; // Direction of player movement
    private float currentSpeed; // Current movement speed

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Get the reference to the Rigidbody component
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized; // Normalize the input to get movement direction

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true; // Set jump request flag when Space key is pressed
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer); // Check if the player is grounded using a raycast
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.red); // Draw a debug ray to visualize the ground check

        if (isGrounded)
        {
            // coyoteTimeCounter = coyoteTime; // Reset coyote time counter when grounded
            jumpCount = 0; // Reset jump count when grounded
        }
        
        if (jumpRequest)
        {
            if (isGrounded )
            {
                isJumping = true; // Set jumping flag if jump is allowed
                jumpCount++; // Increase jump count
            }
            else if (jumpCount < maxJumpCount)
            {
                isJumping = true; // Set jumping flag if additional jumps are allowed
                jumpCount++; // Increase jump count
                rb.angularVelocity = new Vector3(0, 0, 360); // Rotate the player when jumping
            }
            
           
            jumpRequest = false; // Reset jump request flag
        }

        if (isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); // Apply jump force
            isJumping = false; // Reset jumping flag
        }

        float targetSpeed = moveDirection.magnitude * moveSpeed; // Calculate target movement speed
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.fixedDeltaTime * (moveDirection.magnitude > 0 ? acceleration : deceleration)); // Smoothly change current speed based on target speed
        Vector3 moveVelocity = moveDirection * currentSpeed; // Calculate movement velocity
        moveVelocity.y = rb.velocity.y; // Preserve vertical velocity
        rb.velocity = moveVelocity; // Apply movement velocity to the Rigidbody


        if (moveVelocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVelocity.normalized); // Calculate the target rotation based on the movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 3); // Smoothly rotate the player towards the target rotation
        }
        else
        {
            Quaternion defaultRotation = Quaternion.Euler(0f, 0f , 0f); // Calculate the default rotation with only Y-axis rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultRotation, Time.fixedDeltaTime * 3); // Smoothly rotate the player towards the default rotation
        }

    
    }
}
