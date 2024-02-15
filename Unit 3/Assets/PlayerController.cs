using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _speed = 10.0f;  

    private bool _isGrounded;
    private float _jumpHeight = 10.0f;
    private float _gravity = 0.8f;
    private Rigidbody _rb;
    private float _initialy;

    // Start is called before the first frame update
    public void Start()
    {
        _isGrounded = true;
    }
    // Update is called once per frame
    public void Update()
    {
        _rb = GetComponent<Rigidbody>();
        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(dir * _speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _initialy = transform.position.y;
            _isGrounded = false;
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
        if (!_isGrounded)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y - _gravity, _rb.velocity.z);
        }
        if (transform.position.y <= _initialy)
        {
            _isGrounded = true;
        }
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;


        
        
        
    }
}
