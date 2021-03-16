using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    public float speed;
    public SpriteRenderer renderer;
    public Transform player;

    bool isGoingRight;
    bool lookPlayer = false;
    Vector2 playerDistance;
    Animator anim;


    public int maxHealth = 100;
    public int damage = 10;
    private int currentHealth;
    private bool isDead;
    private void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        _ = lookPlayer == player;
        if (!lookPlayer)
        {
            if (!isGoingRight)
            {
                transform.position = startPoint.transform.position;
            }
            else
            {
                transform.position = endPoint.transform.position;
            }
        }
        else
        {
            playerDistance.x = player.transform.position.x - transform.position.x;
            transform.position = new Vector3(playerDistance.x, playerDistance.y, 0);
        }

    }
    private void Update()
    {
        if (!lookPlayer)
        {
            if (!isGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, speed * Time.deltaTime);
                if (transform.position == endPoint.transform.position)
                {
                    isGoingRight = true;
                    renderer.flipX = true;
                }
            }
            if (isGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, speed * Time.deltaTime);
                if (transform.position == startPoint.transform.position)
                {
                    isGoingRight = false;
                    renderer.flipX = false;
                }
            }

        }
        else if (lookPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

    }
    public void TakeDamage(int currentDamage)
    {
        currentHealth -= currentDamage;

        //Play hurt animation
        anim.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        Debug.Log("Enemy died!");
        //Die animation
        anim.SetBool("IsDead", true);
        //disable enemy

        StartCoroutine(EnemyDie());
    }
    IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
