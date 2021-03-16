using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Consumibleitem : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string description;
    public Sprite image;
    public int health;
    public int mana;
}
