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

    private void OnTriggerEnter(Collider other)         //uses a trigger to identify if the bucket is there
    {
        if(other.CompareTag("Bucket"))
        {
            water.SetActive(true);      //sets the bucket active, for the quest
        }
    }
}
