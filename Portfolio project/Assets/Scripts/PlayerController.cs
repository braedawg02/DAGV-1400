using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private Camera playerCamera;

    private float xRotation = 0f;
    public List<GameObject> inventory = new List<GameObject>();
    public bool isGamePaused = false;
    public bool isInventoryOpen = false;
    public float timeScale = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        rb.AddForce(movement * movementSpeed);

        // Limit the maximum speed
        if (rb.velocity.magnitude > movementSpeed)
        {
            rb.velocity = rb.velocity.normalized * movementSpeed;
        }

        // Player rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetButtonDown("Cancel"))
        {
            if (isGamePaused)
            {
                UnityEngine.Time.timeScale = timeScale;
                isGamePaused = false;
            }
            else
            {
                UnityEngine.Time.timeScale = 0f;
                isGamePaused = true;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
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
            if (hit.collider.gameObject.tag == "Tree")
            {
                Rigidbody targetRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                if (targetRigidbody != null)
                {
                    targetRigidbody.isKinematic = false;
                    targetRigidbody.AddRelativeForce(Vector3.forward * 10f, ForceMode.Impulse);
                }
            }
            if (hit.collider.gameObject.tag == "Pickup")
            {
                AddToInventory(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);

            }
        }
        
    }
    public void AddToInventory(GameObject item)
    {
        
        inventory.Add(item);
    }
    public void RemoveFromInventory(GameObject item)
    {
        item.AddComponent(typeof(Rigidbody));
        Instantiate(item, transform.position + transform.forward, Quaternion.identity);
        inventory.Remove(item);
    }
}
