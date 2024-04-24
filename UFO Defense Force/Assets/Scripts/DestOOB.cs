using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyoutofbounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -5)
        {
            Destroy(gameObject);
            MainMenu.EndGame();

        }
        else if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > 15)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
        else if (MainMenu.isGameActive == false)
        {
            Destroy(gameObject);
        }
    }
}
