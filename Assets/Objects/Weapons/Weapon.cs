using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IInteractable
{
    [SerializeField] protected WeaponData _weaponData;
    public string InteractionText => _weaponData.WeaponName;
    public WeaponData WeaponData => _weaponData;

    private float _lastAttackTime;
    private float _lastSecondaryAttackTime;
    private float _lastSkillTime;

    public bool CanAttack()
    {
        return Time.time - _lastAttackTime >= _weaponData.AttackCooldown;
    }

    public bool CanSecondaryAttack()
    {
        return Time.time - _lastSecondaryAttackTime >= _weaponData.SecondaryAttackCooldown;
    }

    public bool CanUseSkill()
    {
        return Time.time - _lastSkillTime >= _weaponData.SkillCooldown;
    }

    public virtual void Attack() 
    {
        if (CanAttack())
        {
            _lastAttackTime = Time.time;
            // Attack logic
        }
    }

    public virtual void SecondaryAttack() 
    {
        if (CanSecondaryAttack())
        {
            _lastSecondaryAttackTime = Time.time;
            // Secondary attack logic
        }
    }

    public virtual void Skill() 
    {
        if (CanUseSkill())
        {
            _lastSkillTime = Time.time;
            // Skill logic
        }
    }

    public virtual void PlayAttackAnimation(Animator animator) {}
    public virtual void PlaySecondaryAttackAnimation(Animator animator) {}
    public virtual void PlaySkillAnimation(Animator animator) {}

    public virtual void PlayAttackSound(AudioSource audioSource) {}
    public virtual void PlaySecondaryAttackSound(AudioSource audioSource) {}
    public virtual void PlaySkillSound(AudioSource audioSource) {}
    
    public bool Interact(Interactor interactor)
    {
        //Debug.Log(_weaponName + " picked up");
        interactor._weaponManager.EquipWeapon(this);
        return true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        if (transform.parent == null)
        {
            transform.Rotate(Vector3.up, 1.0f);
        }
    }

    public void Reset(Vector3 playerPosition, Quaternion playerRotation)
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

