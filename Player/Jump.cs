using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    #region Public Variables
    public float jumpForce = 8;
    public float jumpTime = 0.8f;//tiempo con el que salto en el aire
    public bool grounded;
    #endregion

    #region Private Variables
    Rigidbody2D rb;
    Animator anim;
    float jumpTimeCounter;//contador para establecer el salto
    bool stoppedJumping;//booleana para parar el salto
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float rad;
    [SerializeField] private LayerMask isGround;
    #endregion

 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTime = Time.deltaTime;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
         grounded = Physics2D.OverlapCircle(groundCheck.position, rad, isGround);
        //Prueba de salto

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            anim.SetBool("Jumping", false);
        }
        //si presionamos boton salto
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedJumping = false;
            anim.SetBool("Jumping", true);
        }
        //si mantenemos el boton salto
        if (Input.GetButton("Jump") && !stoppedJumping && jumpTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            anim.SetBool("Jumping", true);
        }
        //si levantamos el boton
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            anim.SetBool("Jumping", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, rad);
    }
}
