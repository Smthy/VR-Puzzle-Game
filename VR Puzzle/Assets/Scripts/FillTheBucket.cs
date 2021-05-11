using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTheBucket : MonoBehaviour
{
    public GameObject water;

    private void Start()
    {
        water.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bucket"))
        {
            water.SetActive(true);
        }
    }
}
