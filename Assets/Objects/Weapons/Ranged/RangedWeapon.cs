using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    /* [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject chargedShotPrefab;
    [SerializeField] private GameObject grenadePrefab;

    public override void Attack()
    {
        Debug.Log(this.WeaponData.WeaponName + " shoots ");
        Shoot();
    }

    public override void SecondaryAttack()
    {
        Debug.Log(this.WeaponData.WeaponName + " shoots a charged shot");
        ShootChargedShot();
    }

    public override void Skill()
    {
        Debug.Log(this.WeaponData.WeaponName + " throws a grenade");
        ThrowGrenade();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetDamage(this.WeaponData.Damage);
    }

    private void ShootChargedShot()
    {
        GameObject chargedShot = Instantiate(chargedShotPrefab, firePoint.position, firePoint.rotation);
        chargedShot.GetComponent<Bullet>().SetDamage(this.WeaponData.Damage * 2);
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
        grenade.GetComponent<Grenade>().SetDamage(this.WeaponData.Damage * 3);
    } */
}
