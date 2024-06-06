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

    [SerializeField] private float _attackCooldown;
    public float AttackCooldown => _attackCooldown;

    [SerializeField] private float _secondaryAttackCooldown;
    public float SecondaryAttackCooldown => _secondaryAttackCooldown;

    [SerializeField] private float _skillCooldown;
    public float SkillCooldown => _skillCooldown;

    [SerializeField] private Sprite _primaryWeaponImage;
    public Sprite PrimaryWeaponImage => _primaryWeaponImage;

    [SerializeField] private Sprite _secondaryWeaponImage;
    public Sprite SecondaryWeaponImage => _secondaryWeaponImage;

    [SerializeField] private Sprite _skillImage;
    public Sprite SkillImage => _skillImage;

     [SerializeField] private AudioClip _attackSound;
    public AudioClip AttackSound => _attackSound;

    [SerializeField] private AudioClip _secondaryAttackSound;
    public AudioClip SecondaryAttackSound => _secondaryAttackSound;

    [SerializeField] private AudioClip _skillSound;
    public AudioClip SkillSound => _skillSound;

    [SerializeField] private string _attackAnimation;
    public string AttackAnimation => _attackAnimation;

    [SerializeField] private string _secondaryAttackAnimation;
    public string SecondaryAttackAnimation => _secondaryAttackAnimation;

    [SerializeField] private string _skillAnimation;
    public string SkillAnimation => _skillAnimation;
}
