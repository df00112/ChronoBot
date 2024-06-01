using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IInteractable
{
    [SerializeField] protected WeaponData _weaponData;
    public string InteractionText => _weaponData.WeaponName;

    public virtual void Attack() {}
    public virtual void SecondaryAttack() {}
    public virtual void Skill() {}
    public virtual void Reset(Vector3 playerPosition, Quaternion playerRotation) {}

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
}

