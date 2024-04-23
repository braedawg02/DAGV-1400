using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private float speed = 5f;
    private bool movingRight = true;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x >= 8.5f)
        {
            movingRight = false;
            transform.Translate(Vector3.down);
        }
        else if (transform.position.x <= -8.5f)
        {
            movingRight = true;
            transform.Translate(Vector3.down);
        }

        if (movingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

}
