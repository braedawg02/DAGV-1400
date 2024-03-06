﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    private float horizontalInput;
    private float forwardInput;
    private float turnSpeed = 45;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        if (verticalInput > 0){
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

        }
        else if (verticalInput < 0){
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }
    }
}