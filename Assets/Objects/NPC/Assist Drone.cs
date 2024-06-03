using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistDrone : MonoBehaviour
{
    public float hoverDistance = 2f;
    public float followSpeed = 2f;
    public float attackInterval = 3f;
    public GameObject attackProjectilePrefab;

    private Transform player;
    private float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Initialize()
    {
        lastAttackTime = Time.time;
    }

    void Update()
    {
        FollowPlayer();
        if (Time.time >= lastAttackTime + attackInterval)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = player.position + player.right * hoverDistance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;
            Instantiate(attackProjectilePrefab, transform.position, Quaternion.LookRotation(direction));
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, currentPosition);
            if (distance < minDistance)
            {
                nearestEnemy = enemy;
                minDistance = distance;
            }
        }

        return nearestEnemy;
    }
}
