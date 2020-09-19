using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ar;


    public float speed = 1f;
    private float horizontal;
    public float forceJump = 150f;
    private bool isGrounded = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (rb.velocity.y < 0)
            ar.SetBool("jump", false);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();


        Flip();
    }

    private void Jump()
    {
        isGrounded = false;
        rb.AddForce(Vector2.up * forceJump);
        ar.SetBool("jump", true);
        ar.SetBool("fall", false);

    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        ar.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;

        if (horizontal > 0 && theScale.x < 0)
            theScale.x = theScale.x * -1;
        else if (horizontal < 0 && theScale.x > 0)
            theScale.x = theScale.x  * -1;

        transform.localScale = theScale;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Ground"))
        {
            isGrounded = true;
            ar.SetBool("fall", true);
        }
    }
}
