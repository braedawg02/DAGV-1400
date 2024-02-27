using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWEE : MonoBehaviour
{
    [SerializeField] GameObject spinningWEE = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinningWEE.transform.Rotate(Vector3.forward,900* Time.deltaTime);
        
    }
}
