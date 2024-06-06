using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerData playerData = other.GetComponent<PlayerData>();

            if (playerData != null)
            {
                playerData.TakeDamage(damage);
            }
        }
    }
}
