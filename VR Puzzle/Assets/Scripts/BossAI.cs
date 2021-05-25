using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{

    public NavMeshAgent agent;

    public GameObject player;

    public LayerMask ground, target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        Following();
    }

    void Following()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = 6f;
    }

}
