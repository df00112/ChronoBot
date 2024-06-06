using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Weapons/Ranged Weapon")]
public class RangedWeaponData : ScriptableObject
{
    [SerializeField] private string _weaponName;
    public string WeaponName => _weaponName;

    [SerializeField] private int _damage;
    public int Damage => _damage;

    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;

    [SerializeField] private float _range;
    public float Range => _range;
}