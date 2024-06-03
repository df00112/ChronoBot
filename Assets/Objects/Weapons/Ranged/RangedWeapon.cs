using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject chargedShotPrefab;
    [SerializeField] private GameObject assistDronePrefab;

    public override void Attack()
    {
        Debug.Log(this.WeaponData.WeaponName + " shoots ");
        Shoot();
    }

    public override void SecondaryAttack()
    {
        Debug.Log(this.WeaponData.WeaponName + " fires a charged shot ");
        FireChargedShot();
    }

    public override void Skill()
    {
        Debug.Log(this.WeaponData.WeaponName + " deploys an assist drone ");
        DeployAssistDrone();
    }

    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void FireChargedShot()
    {
        if (chargedShotPrefab != null && firePoint != null)
        {
            Instantiate(chargedShotPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void DeployAssistDrone()
    {
        if (assistDronePrefab != null && firePoint != null)
        {
            var assistDrone = Instantiate(assistDronePrefab, firePoint.position, firePoint.rotation);
            // Optionally, add some movement or behavior to the drone
            AssistDrone droneScript = assistDrone.GetComponent<AssistDrone>();
            if (droneScript != null)
            {
                droneScript.Initialize();
            }
        }
    }
}
