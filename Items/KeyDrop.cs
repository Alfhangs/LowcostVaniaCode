using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDrop : MonoBehaviour
{
    public Key key;
    private SpriteRenderer renderer;
    public GameObject infoKey;
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = key.image;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCombat player = collision.GetComponent<PlayerCombat>();
        if(player != null)
        {
            Inventory2.inventory.AddKey(key);
            infoKey.SetActive(true);
            Destroy(gameObject);
        }
    }
}
