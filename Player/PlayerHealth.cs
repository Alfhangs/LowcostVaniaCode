using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	#region Public Variables
	public int maxHealth = 100;
	public int currentHealth;
	public Slider healthBar;
	public Consumibleitem item;
	public Text potionUI;
	public GameObject gameOverPanel;
	#endregion

	#region Private Variables
	private Animator anim;
	private bool noHit;
	Inventory2 inventory;
	PlayerHealth player;
	#endregion

	private void Start()
    {
		anim = GetComponent<Animator>();
		currentHealth = maxHealth;
		healthBar.maxValue = maxHealth;
		healthBar.value = currentHealth;
		inventory = Inventory2.inventory;
		player = FindObjectOfType<PlayerHealth>();
	}
    private void Update()
    {
		UpdateUI();
		if(Inventory2.inventory.items.Count > 0)
        {
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				UseItem(item);
				Inventory2.inventory.RemoveItem(item);
				UpdateUI();
			}
			else return;  
		}
		
	}
    public void TakeDamage(int damage)
    {
        NewMethod();
        currentHealth -= damage;
        healthBar.value = currentHealth;
        StartCoroutine(NoDamage());
        if (healthBar.value <= 0)
        {
            healthBar.value = currentHealth;
            Die();
        }
    }

    private void NewMethod()
    {
        anim.SetTrigger("Hit");
    }

    public void UseItem(Consumibleitem item)
	{
		currentHealth += item.health;
		if (currentHealth >= maxHealth)
			currentHealth = maxHealth;
	}
	public int GetHealth()
	{
		return currentHealth;
	}
	public void Die()
	{
		StartCoroutine(IsDead());
	}
    IEnumerator NoDamage()
    {
        noHit = true;
        yield return new WaitForSeconds(0.5f);
        noHit = false;
    }
	IEnumerator IsDead()
	{
		anim.SetBool("IsDead", true);
		yield return new WaitForSeconds(2);
		gameOverPanel.SetActive(true);
    }
	public void UpdateUI()
	{
		potionUI.text = "x " + inventory.CountItems(player.item);
		healthBar.value = currentHealth;
	}
	public void Retry()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
