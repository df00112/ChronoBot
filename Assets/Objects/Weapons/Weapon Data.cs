using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Objects/Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string _weaponName;
    public string WeaponName => _weaponName;

    [SerializeField] private int _damage;
    public int Damage => _damage;

    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;

    [SerializeField] private Sprite _primaryWeaponImage;
    public Sprite PrimaryWeaponImage => _primaryWeaponImage;

    [SerializeField] private Sprite _secondaryWeaponImage;
    public Sprite SecondaryWeaponImage => _secondaryWeaponImage;

    [SerializeField] private Sprite _skillImage;
    public Sprite SkillImage => _skillImage;
}
