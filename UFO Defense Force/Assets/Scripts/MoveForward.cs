using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveForward : MonoBehaviour
{   
    public float speed = 20f;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Untagged"){
        speed = 20f;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (gameObject.tag == "Enemy"){
        speed = 5f;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
