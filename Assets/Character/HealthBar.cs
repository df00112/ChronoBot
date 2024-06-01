using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthText;
    
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        UpdateHealthText(health, health);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
        UpdateHealthText(health, (int)healthSlider.maxValue);
    }

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        if (healthText != null)
        {
            healthText.text = currentHealth + " / " + maxHealth;
        }
    }
}
