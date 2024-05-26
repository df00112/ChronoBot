using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lightsaber") || collision.gameObject.CompareTag("Projectile"))
        {
            PlayerData playerData = GetComponent<PlayerData>();
            if (playerData != null)
            {
                playerData.TakeDamage(damageAmount);
                Debug.Log("Remaining health: " + playerData.Health);
            }
            else
            {
                Debug.Log("PlayerData component is missing on the player.");
            }
        }
    }
}
