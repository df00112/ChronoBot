using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon[] _weapons= new Weapon[2];
    private int _currentWeaponIndex = 0;
    private HashSet<Weapon> _pickedUpWeapons= new HashSet<Weapon>();

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
