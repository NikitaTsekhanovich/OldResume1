using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] public Animator animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        vertical = Run(vertical);
        transform.Rotate(0, horizontal*2, 0);
        transform.Translate(0, 0, vertical/10);
        animator.SetFloat("speed", Vector3.ClampMagnitude(new Vector3(vertical, 0, horizontal), 1).magnitude);
    }

    private void Jump()
    {
        var jumpHeight = 4f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector3(0, jumpHeight, Input.GetAxis("Vertical")/10);
        }
    }

    private float Run(float vertical)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        { 
            vertical *= 5;
        }
        return vertical;
    }
}
