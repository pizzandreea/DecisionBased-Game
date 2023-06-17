using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    float health = 100;
    [SerializeField]
    public bool isDead;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isDead = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("isTakingDamage");

        if(health <= 0)
        {
            animator.SetTrigger("isDead");
            isDead = true;
        }
    }
}
