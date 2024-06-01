using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Objects/Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string _weaponName;
    public string WeaponName => _weaponName;

    [SerializeField] private int _damage;
    public int Damage => _damage;

    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;
}
