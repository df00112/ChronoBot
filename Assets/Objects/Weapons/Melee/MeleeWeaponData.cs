using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee Weapon")]
public class MeleeWeaponData : ScriptableObject
{
    [SerializeField] private string _weaponName;
    public string WeaponName => _weaponName;

    [SerializeField] private int _damage;
    public int Damage => _damage;

    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;

    [SerializeField] private float _swingRadius;
    public float SwingRadius => _swingRadius;
}