using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon[] _weapons= new Weapon[2];
    private int _currentWeaponIndex = 0;
    private HashSet<Weapon> _pickedUpWeapons= new HashSet<Weapon>();
    public Transform _playerHand;

    public void EquipWeapon(Weapon weapon)
    {
        if (_pickedUpWeapons.Contains(weapon))
        {
            Debug.Log("Already picked up this weapon");
            return;
        }

        _pickedUpWeapons.Add(weapon);

        if (_weapons[0] != null && _weapons[1] != null)
        {
            _weapons[_currentWeaponIndex] = null;
            _weapons[_currentWeaponIndex] = weapon;
            Debug.Log("Equipped a weapon");
        }
        else
        {
            for (int i = 0; i < _weapons.Length; i++)
            {
                if (_weapons[i] == null)
                {
                    _weapons[i] = weapon;
                    _currentWeaponIndex = i;
                    break;
                }
            }
        }

        Attach(weapon);
    }

    public void Attach(Weapon weapon)
    {
        if (weapon is MeleeWeapon)
        {
            weapon.transform.SetParent(_playerHand);
            weapon.transform.localRotation = Quaternion.Euler(5f, -17f, 100f);
            weapon.transform.localPosition = new Vector3(0.0f, 0.005f, 0.0f);
        } else if (weapon is RangedWeapon)
        {
            weapon.transform.SetParent(_playerHand);
            weapon.transform.localRotation = Quaternion.Euler(-100f, 90f, 0f);
            weapon.transform.localPosition = new Vector3(-0.003f, 0.006f, 0.0f);
        }
        weapon.GetComponent<BoxCollider>().enabled = false;
    }

    public void SwitchWeapon()
    {
        if (_weapons[0] == null || _weapons[1] == null)
            return;

        _currentWeaponIndex = (_currentWeaponIndex + 1) % 2;

        Debug.Log("Switched to weapon: " + _weapons[_currentWeaponIndex].InteractionText);
    }

    public void PerformAttack()
    {
        if (_weapons[0] == null && _weapons[1] == null)
        {
            Debug.Log("Performed punch attack!");
        }
        else
        {
            _weapons[_currentWeaponIndex]?.Attack();
        }
    }

    public void PerformSecondaryAttack()
    {
        if (_weapons[0] == null && _weapons[1] == null)
        {
            Debug.Log("Performed kick attack!");
        }
        else
        {
            _weapons[_currentWeaponIndex]?.SecondaryAttack();
        }
    }

    public void PerformSkill()
    {
        if (_weapons[0] == null && _weapons[1] == null)
        {
            Debug.Log("No skill to perform");
        }
        else
        {
            _weapons[_currentWeaponIndex]?.Skill();
        }
    }
}
