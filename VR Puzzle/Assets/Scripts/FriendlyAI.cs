using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject enemy, player;

    public float runDistance;

    public float lookAtPlayerDistance = 5f;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        float rDistance = Vector3.Distance(transform.position, enemy.transform.position);
        float PDistance = Vector3.Distance(transform.position, player.transform.position);

        if (rDistance < runDistance)
        {
            Flee();
        }
        else if(lookAtPlayerDistance < PDistance)
        {
            LookAtPlayer();
        }
        else
        {
            Wander();
        }

            
    }

    void Wander()
    {
        //Wander a set area
    }
    
    void Flee()
    {
        //Runs Away from enemy   
    }

    void LookAtPlayer()
    {
        //Look at the player when in range and has the water bucket
    }
    
}
