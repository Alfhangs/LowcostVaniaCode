using UnityEngine;

public class Player : MonoBehaviour
{
    #region Public Variables
    public float speed = 10;
    public SpriteRenderer spriteRenderer;
    public int defense;
    public int strength;
    public float dashForce;
    public GameObject takeWeapon;
    public Consumibleitem item;
    public int maxHealth;
    public int maxMana;
    #endregion

    #region Private Variables
    Animator anim;
    bool isDead = false;
    int currentHealth;
    int currentMana;
    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentMana = maxMana;
        currentHealth = maxHealth;
    }
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(item);
            Inventory2.inventory.RemoveItem(item);
        }
    }
    public void UseItem(Consumibleitem item)
    {
        currentHealth += item.health;
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        currentMana += item.mana;
        if (currentMana >= maxMana)
            currentMana = maxMana;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public int GetMana()
    {
        return currentMana;
    }

}
