using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public override void Attack()
    {
        // Implement melee attack logic (e.g., swing the lightsaber)
        Debug.Log(_weaponData.WeaponName + " swings");
    }

    public override void Reset(Vector3 playerPosition, Quaternion playerRotation)
    {
        float dropDistance = 1.0f;
        Vector3 offset = playerRotation * Vector3.forward * dropDistance;
        Vector3 newPosition = playerPosition + offset;
        newPosition.y = 0.73f;

        transform.position = newPosition;
        transform.rotation = Quaternion.identity;

        gameObject.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
    }
}
