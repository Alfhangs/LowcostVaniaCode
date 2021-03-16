using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public Consumibleitem item;
    public int maxHealth;
    public int maxMana;
    private int health;
    private int mana;


    private void Update()
    {
        if (Input.GetKeyDown("Fire3"))
        {
            UseItem(item);
          //  Inventory.inventory.RemoveItem(item);
        }
    }
    public void UseItem(Consumibleitem item)
    {
        health += item.health;
        if (health >= maxHealth)
            health = maxHealth;
        mana += item.mana;
        if (mana >= maxMana)
            mana = maxMana;
    }
}
