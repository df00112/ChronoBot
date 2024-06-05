using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    private Weapon[] _weapons= new Weapon[2];
    private int _currentWeaponIndex = 0;
    private HashSet<Weapon> _pickedUpWeapons= new HashSet<Weapon>();
    public Transform _playerHand;
    public Image _primaryWeaponImage;
    public Image _secondaryWeaponImage;
    public Image _skillImage;
    private Animator _animator;
    private AudioSource _audioSource;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (_pickedUpWeapons.Contains(weapon))
        {
            Debug.Log("Already picked up this weapon");
            return;
        }

        _pickedUpWeapons.Add(weapon);

        if (BothWeaponSlotsOccupied())
        {
            ReplaceCurrentWeapon(weapon);
        }
        else
        {
            EquipInEmptySlot(weapon);
        }

        Attach(weapon);
        UpdateUI();
    }

    private bool BothWeaponSlotsOccupied()
    {
        return _weapons[0] != null && _weapons[1] != null;
    }

    private void ReplaceCurrentWeapon(Weapon weapon)
    {
        DropCurrentWeapon();
        _weapons[_currentWeaponIndex] = weapon;
    }

    private void EquipInEmptySlot(Weapon weapon)
    {
        if (_weapons[_currentWeaponIndex] != null)
        {
            _weapons[(_currentWeaponIndex)].Hide();
        }

        for (int i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i] == null)
            {
                _weapons[i] = weapon;
                _currentWeaponIndex = i;
                return;
            }
        }
    }

    public void DropCurrentWeapon()
    {
        if (_weapons[_currentWeaponIndex] == null)
        {
            Debug.Log("No weapon to drop");
            return;
        }

        Weapon currentWeapon = _weapons[_currentWeaponIndex];
        currentWeapon.transform.SetParent(null);
        currentWeapon.Reset(transform.position, transform.rotation);
        _weapons[_currentWeaponIndex] = null;
        _pickedUpWeapons.Remove(currentWeapon);
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
            weapon.transform.localRotation = Quaternion.Euler(-96.061f, 127.736f, -47.99f);
            weapon.transform.localPosition = new Vector3(-0.004f, 0.0086f, 0.0012f);
        }
        weapon.GetComponent<BoxCollider>().enabled = false;
    }

    public void SwitchWeapon()
    {
        if (_weapons[0] == null || _weapons[1] == null)
            return;

        _currentWeaponIndex = (_currentWeaponIndex + 1) % 2;

        Debug.Log("Switched to weapon: " + _weapons[_currentWeaponIndex].InteractionText);

        // Disable the current weapon
        _weapons[(_currentWeaponIndex + 1) % 2].Hide();
        // Enable the new weapon
        _weapons[_currentWeaponIndex].Show();

        UpdateUI();
    }

    public void PerformAttack()
    {
        if (_weapons[0] == null && _weapons[1] == null)
        {
            Debug.Log("Performed punch attack!");
            _animator.SetTrigger("Punch");
        }
        else
        {
            Weapon currentWeapon = _weapons[_currentWeaponIndex];
            currentWeapon?.Attack();
            currentWeapon?.PlayAttackAnimation(_animator);
            currentWeapon?.PlayAttackSound(_audioSource);
        }
    }

    public void PerformSecondaryAttack()
    {
        if (_weapons[0] == null && _weapons[1] == null)
        {
            Debug.Log("Performed kick attack!");
            _animator.SetTrigger("Kick");
        }
        else
        {
            Weapon currentWeapon = _weapons[_currentWeaponIndex];
            currentWeapon?.SecondaryAttack();
            currentWeapon?.PlaySecondaryAttackAnimation(_animator);
            currentWeapon?.PlaySecondaryAttackSound(_audioSource);
        }
    }

    public void PerformSkill()
    {
        if (_weapons[0] == null && _weapons[1] == null)
        {
            _animator.SetTrigger("HurricaneKick");
        }
        else
        {
            Weapon currentWeapon = _weapons[_currentWeaponIndex];
            currentWeapon?.Skill();
            currentWeapon?.PlaySkillAnimation(_animator);
            currentWeapon?.PlaySkillSound(_audioSource);
        }
    }

    public void UpdateUI()
    {
        if (_weapons[_currentWeaponIndex] != null)
        {
           UpdateIcon(_weapons[_currentWeaponIndex]);
        }
        else
        {
            _primaryWeaponImage.sprite = null;
            _secondaryWeaponImage.sprite = null;
            _skillImage.sprite = null;
        }
    }

    public void UpdateIcon(Weapon weapon)
    {
        if (weapon.WeaponData.PrimaryWeaponImage != null)
        {
            _primaryWeaponImage.sprite = weapon.WeaponData.PrimaryWeaponImage;
        }

        if (weapon.WeaponData.SecondaryWeaponImage != null)
        {
            _secondaryWeaponImage.sprite = weapon.WeaponData.SecondaryWeaponImage;
        }

        if (weapon.WeaponData.SkillImage != null)
        {
            _skillImage.sprite = weapon.WeaponData.SkillImage;
        }
    }
}
