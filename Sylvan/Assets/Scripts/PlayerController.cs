using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private Camera playerCamera;

    private float xRotation = 0f;
    public bool isInventoryOpen = false;
    public GameObject grounder;
    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundMask;
    public static int jumpForce = 50;
    public static int CurrentItemID = 0;


    void Start()
    {
        // Get the player's rigidbody and camera
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        // Get the ground check object and its radius
        groundCheck = grounder.transform;
        groundCheckRadius = grounder.GetComponent<SphereCollider>().radius + 0.1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player movement
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        movement = movement.normalized * movementSpeed;

        // Apply the movement
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);


        // Player rotation
        if (GameTime.isGamePaused == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

        }




        // Pause the game
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameTime.isGamePaused)
            {
                UnityEngine.Time.timeScale = GameTime.timeScale;
                GameTime.isGamePaused = false;
            }
            else
            {
                UnityEngine.Time.timeScale = 0f;
                GameTime.isGamePaused = true;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            rb.AddForce(transform.forward * 2f, ForceMode.Impulse);
        }


        //Interact with objects
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit) && hit.distance <= 3f)
            {
                GameObject targetObject = hit.collider.gameObject;
                Debug.Log("Player is looking at: " + targetObject.name);
            }
            if (hit.collider.gameObject.tag == "Tree") //&& CurrentItemID == 5)
            {
                Rigidbody targetRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (targetRigidbody != null)
                {
                    targetRigidbody.isKinematic = false;
                    targetRigidbody.AddRelativeForce(Vector3.forward * 100f, ForceMode.Impulse);
                }
            }
            if (hit.collider.gameObject.tag == "Pickup")
            {
                InventoryManager.AddToInventory(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);

            }
        }

    }


    
    private bool IsGrounded()
    {
        // Check if the player is touching the ground
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
    }

}
