using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        float y;
        float z;
        UnityEngine.Vector3 randomizedWaypoint;
        

        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            x = Random.Range(-2, 2);
            y = 0;
            z = Random.Range(-2, 2);
            randomizedWaypoint = waypoints[m_CurrentWaypointIndex].position + new UnityEngine.Vector3(x,y,z);
            navMeshAgent.SetDestination (randomizedWaypoint);
        }
    }
}
