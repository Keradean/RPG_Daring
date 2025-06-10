using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Ranged,
    Magic
}

[CreateAssetMenu(fileName = "Weapon_")]
public class Weapon : MonoBehaviour
{
    [Header("Config")]
    public Sprite Icon;
    public WeaponType WeaponType;
    public float Damage;

    // Create a method to apply Projectile damage
    //[Header("Projectile")]



}
