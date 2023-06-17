using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class RandomMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public bool stop = false;

    public Transform centrePoint;
    public Vector3 centrePointPosition;

    public float delay = 10;
    public float timer = 0;

    private void Start()
    {
       agent = GetComponent<NavMeshAgent>(); 
       centrePointPosition  = centrePoint.position;
        
    }

    private void Update()
    {
        

            timer += Time.deltaTime;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 point;

                if (timer > delay)
                {
                    if (RandomPoint(centrePoint.position, range, out point))
                    {
                        // Debug.Log(gameObject.name.ToString() + " goes to " + point);
                        Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                        agent.SetDestination(point);
                        timer = 0;

                    }

                }
            }
        
        
        
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;   
    }

    public void StopChicken()
    {
        stop = true;
        centrePointPosition = new Vector3(11, 0, 17);
        centrePoint = GameObject.Find("ChickenPenCenter").transform;
        range = 4;
        
        agent.SetDestination(centrePoint.position);
        timer = 0;
    }

    


}
