using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPlayerController : PlayerController
{

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        horizontalInput = Input.GetAxis("WASD_Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
        Gravity();
    }



    protected override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && canJump && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);        // Add force that make the player jump.
            canJump = false;                                            // After the jumping, the player cannot jump again.
            StartCoroutine(EnableJumpingAfterDelay(jumpDelay));         // Aftar a few seconds the player will be able to jump again. Fix mid-air double jumping problem.
        }
    }


    // This function is designed to make a delay from the moment the player jumped, until the moment he can jump again
    // The delay time of the delay was set above
    IEnumerator EnableJumpingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Code to execute after the delay
        canJump = true;
    }



}
