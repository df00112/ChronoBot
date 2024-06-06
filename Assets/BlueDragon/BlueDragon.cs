using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDragon : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public GameObject attackArea;
    private Collider attackAreaCollider;
    private int isAttackingHash;
    private bool isAttacking;

    void Awake()
    {
        animator = GetComponent<Animator>();
        attackAreaCollider = attackArea.GetComponent<Collider>();
        isAttackingHash = Animator.StringToHash("isAttacking");
        isAttacking = animator.GetBool(isAttackingHash);
    }

    public void Attack()
    {
        if (isAttacking && !attackAreaCollider.enabled)
        {
            attackAreaCollider.enabled = true;
        }
        else if (!isAttacking && attackAreaCollider.enabled)
        {
            attackAreaCollider.enabled = false;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    void UpdateAttackState()
    {
        isAttacking = animator.GetBool(isAttackingHash);
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAttackState();
    }
}
