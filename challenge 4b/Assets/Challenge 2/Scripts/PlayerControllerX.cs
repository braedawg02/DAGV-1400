using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float shootCooldown = 1.0f;
    private float lastShootTime;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog if enough time has passed since last shoot
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShootTime + shootCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastShootTime = Time.time;
        }
    }
}
