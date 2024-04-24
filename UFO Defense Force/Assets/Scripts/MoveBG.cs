using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public GameObject BG;
    
    private Vector3 RESET_POSITION = new Vector3(0, 0, 0);
    public float SPEED = 1f;
    private float COLLIDER_BOTTOM = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
        COLLIDER_BOTTOM = BG.GetComponent<BoxCollider>().bounds.min.y;
        RESET_POSITION = transform.position;
       
    }
    void Update()
    {
        if(MainMenu.isGameActive == true)
        {
            MoveBackground();
        }
    }
    void MoveBackground()
    {
        transform.Translate(Vector3.down * SPEED * Time.deltaTime);
          if (transform.position.y < COLLIDER_BOTTOM)
        {
            transform.position = RESET_POSITION;
        }
    }
    



        
}

