using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float horizontalMovement;
    #endregion

    #region Private Variables
    Rigidbody2D rb;
    Animator anim;
    bool facingRight = true;
    bool isDead = false;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {

            rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
            var horizontal = Input.GetAxis("Horizontal");
            anim.SetFloat("Running", math.abs(horizontal));
            var x = horizontal * speed * Time.deltaTime;
            Flip(horizontalMovement);
        }
        else
        {
            ReloadScene();
        }
    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    void ReloadScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
