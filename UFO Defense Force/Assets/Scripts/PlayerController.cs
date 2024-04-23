using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject LaserPrefab;
        public float moveSpeed = 5f;        
        private bool canShoot = true;

         // Adjust the speed as needed

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float newPosition = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;
        newPosition = Mathf.Clamp(newPosition, -8.5f, 8.5f);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            StartCoroutine(ShootLaser());
            canShoot = false;
        }
        }

        private IEnumerator ShootLaser()
        {
        Instantiate(LaserPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);

        // Set the speed of the instantiated laser
        LaserPrefab.GetComponent<MoveForward>().speed = 10f;
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
        }

        void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
}
