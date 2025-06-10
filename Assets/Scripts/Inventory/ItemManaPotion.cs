using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;


[CreateAssetMenu(fileName = "items/ManaPotion", menuName = "Items/Mana Potion" )] // Create a new menu item for the mana potion
public class ItemManaPotion : InventoryItem
{
    [Header("Config/ DLC Update")]
    public float ManaValue; // The amount of mana this potion restores
} 

