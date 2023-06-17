using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : MonoBehaviour
{
    public NavMeshAgent agent;
    public float health;
    public Animator animator;

    public Transform player;

    public LayerMask layerGround, layerPlayer;

    //PATROLING

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkRange;

    // Attacking

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states

    public float sightRange, attackRange;
    public bool playerIsInSightRange, playerIsInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = 100f;
    }

    private void Update()
    {
        //check if the player is in sight range or attack range

        if (health <= 0)
        {
            animator.SetBool("Death", true);
        }

        playerIsInSightRange = Physics.CheckSphere(transform.position, sightRange, layerPlayer);
        playerIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, layerPlayer);
        
        if(!playerIsInSightRange && !playerIsInAttackRange)
        {
            Patroling();
        }
        if(playerIsInSightRange && !playerIsInAttackRange)
        {
            ChasePlayer();
        }
        if(playerIsInAttackRange && playerIsInSightRange) 
        {
            AttackPlayer();
        }
    
    }

    private void Patroling()
    {
        if (!walkPointSet)
            SearchWalkPoint();
        else
        {
            agent.SetDestination(walkPoint);
        }

        //if walkpoint reached

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkRange, walkRange);
        float randomX = Random.Range(-walkRange, walkRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //checking if the point is on the ground
        if(Physics.Raycast(walkPoint, -transform.up, 2f, layerGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //make sure the enemy does not move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            //Attack code


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    private void TakeDamage(int damage)
    {
        health -= damage; 
        
    }
}
