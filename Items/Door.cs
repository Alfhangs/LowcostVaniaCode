using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public Key key;
    public Sprite doorOpen;

    private SpriteRenderer renderer;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Inventory2.inventory.CheckKey(key))
            {
                renderer.sprite = doorOpen;
                boxCollider.enabled = false;
            }
        }
    }
}
