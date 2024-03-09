using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f; // The upper boundary for the game object's position
    private float lowerBound = -10.0f; // The lower boundary for the game object's position

    // Start is called before the first frame update
    void Start()
    {
        // Code for initialization goes here
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject); // Destroy the game object if it goes above the top boundary
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!"); // Log "Game Over!" if the game object goes below the lower boundary
            Destroy(gameObject); // Destroy the game object
        }
    }
}
