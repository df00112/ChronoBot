using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaSlider;
    public Text staminaText;
    
    public void SetMaxStamina(int stamina)
    {
        staminaSlider.maxValue = stamina;
        staminaSlider.value = stamina;
        UpdateStaminaText(stamina, stamina);
    }

    public void SetStamina(int stamina)
    {
        staminaSlider.value = stamina;
        UpdateStaminaText(stamina, (int)staminaSlider.maxValue);
    }

    public void UpdateStaminaText(int currentStamina, int maxStamina)
    {
        if (staminaText != null)
        {
            staminaText.text = currentStamina + " / " + maxStamina;
        }
    }
}
