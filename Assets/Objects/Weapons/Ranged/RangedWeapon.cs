using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public override void Attack()
    {
        // Implement ranged attack logic (e.g., shoot the gun)
        Debug.Log(this.WeaponData.WeaponName + " shoots ");
    }
}
