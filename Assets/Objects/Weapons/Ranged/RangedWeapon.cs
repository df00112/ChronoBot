using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject chargedShotPrefab;
    [SerializeField] private GameObject assistDronePrefab;

    void Awake()
    {
        firePoint = GameObject.Find("FirePoint").transform;
    }

    public override void Attack()
    {
        if (CanAttack())
        {
            base.Attack();
            Debug.Log(this.WeaponData.WeaponName + " shoots ");
            Shoot();
        }
    }

    public override void SecondaryAttack()
    {
        if (CanSecondaryAttack())
        {
            base.SecondaryAttack();
            Debug.Log(this.WeaponData.WeaponName + " fires a charged shot ");
            FireChargedShot();
        }
    }

    public override void Skill()
    {
        if (CanUseSkill())
        {
            base.Skill();
            Debug.Log(this.WeaponData.WeaponName + " deploys an assist drone ");
            DeployAssistDrone();
        }
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

            var assistDrone = Instantiate(assistDronePrefab,
                new Vector3(Random.Range(-20f, 20f), 50, Random.Range(-20f, 20f)),
                Quaternion.Euler(0, 0, 0)
            );
            AssistDrone droneScript = assistDrone.GetComponent<AssistDrone>();
            if (droneScript != null)
            {
                droneScript.Initialize();
            }
        }
    }

    public override void PlayAttackAnimation(Animator animator)
    {
        animator.SetTrigger(_weaponData.AttackAnimation);
    }

    public override void PlaySecondaryAttackAnimation(Animator animator)
    {
        animator.SetTrigger(_weaponData.SecondaryAttackAnimation);
    }

    public override void PlaySkillAnimation(Animator animator)
    {
        animator.SetTrigger(_weaponData.SkillAnimation);
    }

    public override void PlayAttackSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(_weaponData.AttackSound);
    }

    public override void PlaySecondaryAttackSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(_weaponData.SecondaryAttackSound);
    }

    public override void PlaySkillSound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(_weaponData.SkillSound);
    }
}
