using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The game object to follow
    public float distance = 5f; // The distance between the camera and the target
    public float height = 2f; // The height of the camera above the target
    public float smoothSpeed = 10f; // The smoothness of camera movement

    private Vector3 offset; // The offset between the camera and the target

    private void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;
        desiredPosition += -transform.forward * distance; // Apply distance offset
        desiredPosition += Vector3.up * height; // Apply height offset

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
