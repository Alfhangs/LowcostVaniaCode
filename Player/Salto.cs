using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMutliplier = 2f;
    public bool grounded;

    Rigidbody2D rb;
    Animator anim;
    private void Awake()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        anim = transform.parent.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            grounded = false;
            anim.SetBool("Jumping", true);

        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMutliplier - 1) * Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("Jumping", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
