using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterBreating : MonoBehaviour
{
    public bool waterBreating;
    public float airTimer;

    private void Start()
    {
        waterBreating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !waterBreating)
        {
            airTimer = 10f;            
        }

        if (other.CompareTag("Player") && !waterBreating)
        {
            airTimer = 1000f;
        }

        StartCoroutine("Water");
    }

    IEnumerator Water()
    {
        yield return new WaitForSeconds(airTimer);       
        
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine("Water");
    }
}
