using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health = 500;
	public GameObject credits;
	AudioSource audio1;

	Animator anim;
	bool hellFire;
	public bool isInvulnerable = false;

    private void Start()
    {
		anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
		anim.SetTrigger("Hit");

		if (health <= 200 && !hellFire)
		{
			hellFire = true;
			print("200");
			anim.SetBool("IsEnraged", true);
			anim.SetBool("IsHellFire", true);
			isInvulnerable = true;
			anim.Play("HellFire");
			print("180");
		}

		if (health <= 0)
		{
			anim.SetBool("IsDead", true);
		}
	}

	public void Die()
	{
		Destroy(gameObject);
		credits.SetActive(true);
		Camera.main.GetComponent<AudioSource>().Stop();

		//audio1.volume = 0;
	}
	public void IsEnraged()
    {
		print("Entro enraged");
		GetComponent<Animator>().SetBool("IsEnraged", true);
		anim.SetBool("IsHellFire", false);
		isInvulnerable = false;
	}
}
