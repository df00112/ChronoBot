using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IInteractable
{
    [SerializeField] protected string _weaponName;
    public string InteractionText => _weaponName;

    public virtual void Attack() {}
    public virtual void SecondaryAttack() {}
    public virtual void Skill() {}

    public bool Interact(Interactor interactor)
    {
        Debug.Log(_weaponName + " picked up");
        interactor._weaponManager.EquipWeapon(this);
        gameObject.SetActive(false);
        return true;
    }
}

