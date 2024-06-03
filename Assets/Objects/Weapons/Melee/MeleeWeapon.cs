using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public override void Attack()
    {
        // Implement melee attack logic (e.g., swing the lightsaber)
        Debug.Log(this.WeaponData.WeaponName + " swings");
    }
}
