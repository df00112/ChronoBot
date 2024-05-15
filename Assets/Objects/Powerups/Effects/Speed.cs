using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Powerup", menuName = "Powerups/Speed")]
public class Speed : PowerupEffect
{
    public float _speedMultiplier = 1.2f;
    public override void ApplyEffect(GameObject target)
    {
        PlayerData playerData = target.GetComponent<PlayerData>();
        if (playerData != null)
        {
            playerData.MovementSpeed *= _speedMultiplier;
            Debug.Log("Speed increased by " + _speedMultiplier);
        }
    }
}
