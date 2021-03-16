using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public static Inventory2 inventory;
    public List<Key> keys;
    public List<Consumibleitem> items;

    private void Awake()
    {
        if (inventory == null)
            inventory = this;
        else if (inventory != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void AddKey(Key key)
    {
        keys.Add(key);
    }
    public bool CheckKey(Key key)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i] == key)
            {
                return true;
            }
        }
        return false;
    }
    public void AddItem(Consumibleitem item)
    {
        items.Add(item);
    }
    public void RemoveItem(Consumibleitem item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                items.RemoveAt(i);
                break;
            }
        }
    }
    public int CountItems(Consumibleitem item)
    {
        return items.Count;
    }
}
