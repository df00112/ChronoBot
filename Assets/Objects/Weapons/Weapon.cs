using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IInteractable
{
    [SerializeField] protected WeaponData _weaponData;
    public string InteractionText => _weaponData.WeaponName;
    public WeaponData WeaponData => _weaponData;

    // May not be needed methods for all weapons
    public virtual void Attack() {}
    public virtual void SecondaryAttack() {}
    public virtual void Skill() {}

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

