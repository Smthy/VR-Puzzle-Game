using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainQuest : MonoBehaviour
{
    public ParticleSystem water;
    public GameObject key, waterInBucket;
    

    private void Start()
    {
        water.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bucket") && waterInBucket)
        {
            Rigidbody rb = Instantiate(key, transform.position, Quaternion.identity).GetComponent<Rigidbody>(); 
            rb.AddForce(transform.up * 50f, ForceMode.Impulse);

            water.Play();
        }
    }

}
