using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;
    public int damage = 10;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            BlueDragon enemy = other.GetComponent<BlueDragon>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
