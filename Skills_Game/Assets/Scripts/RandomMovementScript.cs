using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovementScript : MonoBehaviour
{

    public NavMeshAgent agent;
    public float range;

    public Transform centrePoint;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);

            }

        }
    }


    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 RandomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }


        result = Vector3.zero;
        return false;

    }

   

}
