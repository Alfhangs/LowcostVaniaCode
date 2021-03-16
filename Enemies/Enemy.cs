using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;

    private Animator anim;
   // public GameObject bloodEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", true);
    }
    private void Update()
    {
        if(dazedTime <= 0)
        {
            //speed = 5;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        //Play a hurt sound
        //Instantiate(bloodEffect, transform.position, quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN");
    }





    //public float speed;
    //public Transform player;
    //public int health;
    //public GameObject itemDrop;
    //public Consumibleitem item;
    //public int damage;

    //Rigidbody2D rb;
    //Animator anim;
    //Vector2 playerDistance;
    //bool facingRight = false;
    //bool isDead = false;
    //SpriteRenderer renderer;

    //private void Start()
    //{

    //    playerDistance = new Vector2(0, 0);
    //    rb = GetComponent<Rigidbody2D>();
    //    anim = GetComponent<Animator>();
    //    renderer = GetComponent<SpriteRenderer>();
    //}
    //private void FixedUpdate()
    //{
    //    if (!isDead)
    //    {
    //        playerDistance.x = player.transform.position.x - transform.position.x;
    //        //Abs para pasar a valores absolutos
    //        if (Mathf.Abs(playerDistance.x) < 100 || Mathf.Abs(playerDistance.y) > 2)
    //        {
    //            print("ahsasdasda");
    //            rb.velocity = new Vector2(speed * (playerDistance.x / Mathf.Abs(playerDistance.x)), rb.velocity.y);
    //        }
    //        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    //        if (rb.velocity.x > 0 && !facingRight)
    //        {
    //            Flip();
    //        }
    //        else if (rb.velocity.x < 0 && facingRight)
    //        {
    //            Flip();
    //        }
    //    }

    //}
    //public void Flip()
    //{
    //    facingRight = !facingRight;

    //    Vector3 scale = transform.localScale;
    //    scale.x *= -1;
    //    transform.localScale = scale;
    //}
    //public void TakeDamage(int damage)
    //{
    //    health -= damage;
    //    if (health <= 0)
    //    {
    //        isDead = true;
    //        rb.velocity = Vector2.zero;
    //        anim.SetTrigger("Dead");
    //        FindObjectOfType<UIManager>().UpdateUI();
    //        if (item != null)
    //        {
    //            GameObject tempItem = Instantiate(itemDrop, transform.position, transform.rotation);
    //            tempItem.GetComponent<ItemDrop>().item = item;
    //        }
    //    }
    //    else
    //    {
    //        StartCoroutine(DamageEnemy());
    //    }
    //}
    //IEnumerator DamageEnemy()
    //{
    //    for (float i = 0; i < 0.2f; i+=0.2f)
    //    {
    //        renderer.color = Color.red;
    //        yield return new WaitForSeconds(0.1f);
    //        renderer.color = Color.white;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}
    //public void DestroyEnemy()
    //{
    //    Destroy(gameObject);
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Player player = collision.gameObject.GetComponent<Player>();
    //    if(player != null)
    //    {
    //        player.TakeDamage(damage);
    //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10 * (playerDistance.x / Mathf.Abs(playerDistance.x)), ForceMode2D.Impulse);
    //    }
    //}
}
