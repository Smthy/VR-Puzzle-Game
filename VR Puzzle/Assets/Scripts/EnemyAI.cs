using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float minX, maxX, minZ, maxZ;

    public NavMeshAgent agent;

    public GameObject player;

    public LayerMask ground, target;

    public Vector3 walkpoint;
    bool pointSet;

    public float sight, attack;
    public bool playerInRange, playerInSight;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine("WalkTimer");
    }
    void FixedUpdate()
    {
        playerInSight = Physics.CheckSphere(transform.position, sight, target);
        playerInRange = Physics.CheckSphere(transform.position, attack, target);

        if(playerInSight && !playerInRange)
        {
            Following();
        }
        else if (playerInSight && playerInRange)
        {
            Attack();
        }
        else if(!playerInSight && !playerInRange)
        {
            Wander();
        }


    }

    void Wander()
    {
        agent.speed = 6f;

        if (!pointSet)
        {
            SearchDestination();
        }

        if (pointSet)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceToPoint = transform.position - walkpoint;

        if (distanceToPoint.magnitude <= 1f)
        {
            pointSet = false;
        }
    }

    void Following()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = 6f;
    }

    void Attack()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = 12f;
    }

    void SearchDestination()
    {
        float randomX = Random.Range(minX, maxX);
        float RandomZ = Random.Range(minZ, maxZ);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + RandomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, ground))
        {
            pointSet = true;
        }
    }


    IEnumerator WalkTimer()
    {
        yield return new WaitForSeconds(20f);
        
        pointSet = false;


        StartCoroutine("WalkTimer");
    }
}
