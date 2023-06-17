using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject player;

    public float EnemyDistanceRun = 6.0f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Debug.Log("Distance: " + distance); 

        // run away from the player
        if (distance < EnemyDistanceRun)
        {
            Vector3 directionToPlayer = transform.position - player.transform.position;

            Vector3 newPosition = transform.position + directionToPlayer;

            agent.SetDestination(newPosition);
            agent.speed = 6;
        }
        else
        {
            agent.speed = 1.2f;
        }


    }
}
