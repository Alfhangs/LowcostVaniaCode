using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator anim;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        anim.SetTrigger("Hit");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //Die animation
        anim.SetBool("IsDead", true);
        //disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
