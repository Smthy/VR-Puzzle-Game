using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    public LayerMask ground, target;

    private Vector3 walkpoint;
    bool travelling;

    public float sight, attack;
    public bool playerInRange, playerInSight;

    public GameObject currentWaypoint;
    GameObject previousWaypoint;
    GameObject[] allWaypoints;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        allWaypoints = GameObject.FindGameObjectsWithTag("Node");
        currentWaypoint = GetRandomWaypoint();
        SetDestination();

    }

    void FixedUpdate()
    {
        playerInSight = Physics.CheckSphere(transform.position, sight, target);
        playerInRange = Physics.CheckSphere(transform.position, attack, target);

        if(!playerInSight && !playerInRange)
        {
            Wander();
        }

        if (playerInSight && !playerInRange)
        {
            Following();
        }
        
        if (playerInSight && playerInRange)
        {
            Attack();
        }
        
        
    }

    void Wander()
    {
        if (travelling && agent.remainingDistance <= 1f)
        {
            travelling = false;
            SetDestination();
        }
    }

    void Following()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = 5f;
    }

    void Attack()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = 6f;
    }

    void SetDestination()
    {
        previousWaypoint = currentWaypoint;
        currentWaypoint = GetRandomWaypoint();

        walkpoint = currentWaypoint.transform.position;
        agent.SetDestination(walkpoint);
        travelling = true;
    }

    public GameObject GetRandomWaypoint()
    {
        if (allWaypoints.Length == 0)
        {
            return null;
        }
        else
        {
            int index = Random.Range(0, allWaypoints.Length);
            return allWaypoints[index];
        }
    }
}
