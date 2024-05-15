using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Powerup", menuName = "Powerups/Health Recover")]
public class HealthRecover : PowerupEffect
{
    public int _healthRecovered = 10;

    public override void ApplyEffect(GameObject target)
    {
        PlayerData playerData = target.GetComponent<PlayerData>();
        if (playerData != null)
        {
            playerData.Health += _healthRecovered;
            Debug.Log("Health recovered by " + _healthRecovered);
            Debug.Log("Current health: " + playerData.Health);
        }
    }
}
