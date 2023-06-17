using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 50;

    [Header("Combat")]
    // attack cooldown (pauze intre atacuri)
    [SerializeField]
    float attackCD = 3f;
    [SerializeField]
    float attackRange = 1f;
    [SerializeField]
    float aggroRange = 4f;
    [SerializeField]
    public bool isDead = false;

    GameObject player;
    Animator animator;
    NavMeshAgent agent;
    float timePassed;
    // cooldown ul deplasarii (pentru a face pauze ca in realitate)
    float newDestinationCD = 0.5f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
         
        // normalizarea vitezei pentru a avea valori intr
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        if(timePassed >= attackCD)
        {
            //  daca se afla in range-ul de atac
            if(Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("isAttacking");
                timePassed = 0;
            }
        }
        if (!isDead)
        {
            timePassed += Time.deltaTime;

            if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
            {
                newDestinationCD = 0.5f;
                agent.SetDestination(player.transform.position);
            }

            newDestinationCD -= Time.deltaTime;
            transform.LookAt(player.transform);
        }
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

    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,aggroRange);
    }

}
