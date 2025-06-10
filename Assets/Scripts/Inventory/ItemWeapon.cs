using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Weapon", fileName = "ItemWeapon")]
public class ItemWeapon : InventoryItem
{
    [Header("Weapon")]
     public Weapon weapon; // Reference to the Weapon scriptable object that contains weapon-specific data

    public class Weapon 
    { 
    }

}

