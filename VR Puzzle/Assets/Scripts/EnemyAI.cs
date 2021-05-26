using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    public LayerMask ground, target;            //uses a layer mask instead of tag, due to the physics of the world

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
        SetDestination();                           //uses nodes instead of random position, since the map has different heights

    }

    void FixedUpdate()
    {
        playerInSight = Physics.CheckSphere(transform.position, sight, target);
        playerInRange = Physics.CheckSphere(transform.position, attack, target);                        //Checks if the player is in sight. Uses fixed update for the physics instead of a normal one. this is also less demanding on the system

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
        agent.SetDestination(player.transform.position);            //stalks the player to the point it is in attack range
        agent.speed = 5f;
    }

    void Attack()
    {
        agent.SetDestination(player.transform.position);                    //if the player is in range, it will attack, increase of speed to scare the player
        agent.speed = 6f;
    }

    void SetDestination()
    {
        previousWaypoint = currentWaypoint;
        currentWaypoint = GetRandomWaypoint();

        walkpoint = currentWaypoint.transform.position;
        agent.SetDestination(walkpoint);                                                //sets the destination for the AI to allow them to walk around the areas
        travelling = true;
    }

    public GameObject GetRandomWaypoint()
    {
        if (allWaypoints.Length == 0)
        {
            return null;
        }                                                                           //uses an array to find the next node for the AI to walk to
        else
        {
            int index = Random.Range(0, allWaypoints.Length);
            return allWaypoints[index];
        }
    }
}
