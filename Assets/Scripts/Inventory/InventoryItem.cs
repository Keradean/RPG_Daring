using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    QuestItem,
    Treasure,
    Ingredients,
    Scroll
}
[CreateAssetMenu(menuName = "Items/ Item")]
public class InventoryItem : ScriptableObject
{
    [Header("Config")]
    public string ID;
    public string Name;
    public Sprite Icon;
    [TextArea]public string Description;

    [Header("Item Infos")]
    public ItemType ItemType;  // Type of the item (Weapon, Armor, etc.)
    public bool IsConsumable; // If true, the item can be consumed or used
    public bool IsStackable; // If true, the item can be stacked in the inventory
    public int MaxStack;    // Maximum number of items that can be stacked together

    [HideInInspector] public int Quantity; // Current quantity of the item in the inventory

    public InventoryItem CopyItem()
    {
        InventoryItem instance = Instantiate(this); // Create a new instance of the item
        return instance; // Return the new instance
    }

    public virtual bool UseItem() // Method to use the item, if applicable
    {
        return true; // Default implementation for using the item
        
    }

    public virtual void EquipItem() // Method to equip the item, if applicable
    {
        
    }

    public virtual void RemoveItem() // Method to remove the item, if applicable
    {

    }

}
