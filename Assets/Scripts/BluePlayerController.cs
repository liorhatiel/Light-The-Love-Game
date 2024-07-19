using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerController : PlayerController
{
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Jump();

    }

    private void FixedUpdate()
    {
        Move();
        Gravity();
    }



}



