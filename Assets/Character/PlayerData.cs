using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private string _playerName = "Player";
    public string PlayerName => _playerName;

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health = 100;

    [SerializeField] private int _maxStamina = 100;
    [SerializeField] private int _stamina = 100;
    [SerializeField] private int _staminaConsumeRate = 10;
    [SerializeField] private int _staminaRegenRate = 10;
    [SerializeField] private float _staminaRegenDelay = 5.0f;
    [SerializeField] private float _staminaRegenTimer = 0.0f;

    public static PlayerData playerData;

    // Display variables
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private StaminaBar _staminaBar;

    void Awake()
    {
        if (playerData == null)
        {
            playerData = this;
        }
        else
        {
            Destroy(playerData);
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        if (_healthBar != null)
        {
            _healthBar.SetMaxHealth(_maxHealth);
            _healthBar.SetHealth(_health);
        }

        if (_staminaBar != null)
        {
            _staminaBar.SetMaxStamina(_maxStamina);
            _staminaBar.SetStamina(_stamina);
        }
    }

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_healthBar != null)
            {
                _healthBar.SetHealth(_health);
            }
        }
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            _maxHealth = value;
            if (_healthBar != null)
            {
                _healthBar.SetMaxHealth(_maxHealth);
            }
        }
    }

    [SerializeField] private float _movementSpeed = 3.0f;
    public float MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }

    public int Stamina
    {
        get => _stamina;
        set
        {
            _stamina = value;
            if (_staminaBar != null)
            {
                _staminaBar.SetStamina(_stamina);
            }
        }
    }

    public int MaxStamina
    {
        get => _maxStamina;
        set
        {
            _maxStamina = value;
            if (_staminaBar != null)
            {
                _staminaBar.SetMaxStamina(_maxStamina);
            }
        }
    }
    public int StaminaConsumeRate
    {
        get => _staminaConsumeRate;
        set => _staminaConsumeRate = value;
    }

    public int StaminaRegenRate
    {
        get => _staminaRegenRate;
        set => _staminaRegenRate = value;
    }

    public float StaminaRegenDelay
    {
        get => _staminaRegenDelay;
        set => _staminaRegenDelay = value;
    }

    public float StaminaRegenTimer
    {
        get => _staminaRegenTimer;
        set => _staminaRegenTimer = value;
    }
}
