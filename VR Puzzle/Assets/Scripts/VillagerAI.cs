using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Vector3 destination;
    bool destinationset;
    public float walkrange;

    public LayerMask ground;

    public float minX, maxX, minZ, maxZ;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
