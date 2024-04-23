using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // This method is called when a collision occurs
    void OnTriggerEnter(Collider other)
    {
        // Destroy the current object
        Destroy(gameObject);

        // Destroy the other object involved in the collision
        Destroy(other.gameObject);
    }
}
