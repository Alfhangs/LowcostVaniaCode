using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    #region Public Variables
    public Animator anim;
    public Transform attackPos;
    public float attackRange = 1.4f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackRate = 2f;
    #endregion

    #region Private Variables
    float nextAttackTime = 0;
    #endregion


    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    public void Attack()
    {
        //Play an attack animation
        anim.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            NewMethod(enemy);
        }
    }
    void NewMethod(Collider2D enemy)
    {
        if (enemy.GetComponent<Enemy_Behaviour>())
            enemy.GetComponent<Enemy_Behaviour>().TakeDamage(attackDamage);
        else if (enemy.GetComponent<BossHealth>())
            enemy.GetComponent<BossHealth>().TakeDamage(attackDamage);
        else if (enemy.GetComponent<Bat>())
            enemy.GetComponent<Bat>().TakeDamage(attackDamage);
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPos == null)
            return;

        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
