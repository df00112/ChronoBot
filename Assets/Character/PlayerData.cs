using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private string _playerName = "Player";
    public string PlayerName => _playerName;

    [SerializeField] private int _maxHealth = 100;
    public int MaxHealth => _maxHealth;

    [SerializeField] private int _health = 100;
    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, _maxHealth);
    }

    [SerializeField] private float _movementSpeed = 3.0f;
    public float MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }
}
