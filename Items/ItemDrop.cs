using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Consumibleitem item;
    private SpriteRenderer renderer;
    private PlayerHealth healthPlayer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.image;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory2.inventory.AddItem(item);
            //  FindObjectOfType<UIManager>().UpdateUI();
            //healthPlayer.currentHealth++;
            Destroy(gameObject);
        }
    }
}
