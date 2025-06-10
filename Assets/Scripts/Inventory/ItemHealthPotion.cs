using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemHealthPotion", menuName = "Items/Health Potion")] // Create a new menu item for the health potion
public class ItemHealthPotion : InventoryItem
{
    
    [Header("Config/ DLC Update")]
    public float HelathValue; // The amount of health this potion restores



}
