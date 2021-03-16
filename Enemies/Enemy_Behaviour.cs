using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region Public Variables
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform startPos;
    public Transform endPos;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public int maxHealth = 100;

    public Transform attackPos;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int damage = 10;
    #endregion

    #region Private Variables
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    private int currentHealth;
    private bool isDead;
    #endregion

    private void Awake()
    {
        currentHealth = maxHealth;
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!isDead)
        {
            if (!attackMode)
            {
                Move();
            }
            //si no esta en los limites y ni tampoco en el rango ni en la animacion de atacar selecciono al objetivo
            if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                SelectTarget();
            }
            if (inRange)
            {
                EnemyLogic();
            }
        }
        else Die();
        
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
            cooling = true;
        }
        if (cooling)
        {
            Cooldown();
            //anim.SetBool("Attack", false);
        }
    }
    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    public void Attack()
    {
        print("asd");
        timer = intTimer; //Reinicia el temporizador cuando el jugador entre en el rango de ataque
        attackMode = true; // para comprobar si el enemigo puede atacar o no

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);

        //Detectar al jugador en el rango de ataque
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerLayer);

        //Ataca 
        foreach (Collider2D player in hitPlayer)
        {
            NewMethod(player);
        }

    }
    public void DesactiveAttack()
    {
        anim.SetBool("Attack", false);
    }
    void NewMethod(Collider2D player)
    {
        print("daño");
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
    void Cooldown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
    private bool InsideOfLimits()
    {
        return transform.position.x > startPos.position.x && transform.position.x < endPos.position.x;
    }
    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, startPos.position);
        float distanceToRight = Vector2.Distance(transform.position, endPos.position);

        if (distanceToLeft > distanceToRight)
        {
            target = startPos;
        }
        else
        {
            target = endPos;
        }
        Flip();
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;

    }
    public void TakeDamage(int currentDamage)
    {
        currentHealth -= currentDamage;

        //Play hurt animation
        anim.SetTrigger("Hit");
        timer = intTimer;

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
}
