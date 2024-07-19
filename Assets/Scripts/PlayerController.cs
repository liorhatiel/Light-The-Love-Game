using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Those below if for the player movement.
    protected float movementSpeed = 450;
    protected float horizontalInput;

    // Those below if for the player jump abillity.
    protected bool isGrounded;
    protected bool canJump = true;
    protected float jumpForce = 18;
    protected float gravity = 1f;
    protected float jumpDelay = .3f;

    // This is for get a refrence for the Rigidbode2D componenet. 
    protected Rigidbody2D rb;
    


    protected void Move()
    {
        rb.velocity = new Vector2(horizontalInput * movementSpeed * Time.fixedDeltaTime , rb.velocity.y);
    }

    protected void Gravity()
    {
        rb.velocity += Vector2.down * gravity;
    }

    protected virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && canJump)
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }


}
