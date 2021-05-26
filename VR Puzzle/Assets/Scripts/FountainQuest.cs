using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainQuest : MonoBehaviour
{
    public ParticleSystem water;
    public GameObject key, waterInBucket;

    public float randomForceUp, randomForceForward;
    

    private void Start()
    {
        water.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bucket") && waterInBucket)
        {
            randomForceForward = Random.Range(10f, 30f);
            randomForceUp = Random.Range(1f, 10f);

            Rigidbody rb = Instantiate(key, transform.position, Quaternion.identity).GetComponent<Rigidbody>();             //Uses physics to shoot the key in a direction to allow the key to be moved from the fountain, for the players benefit
            rb.AddForce(transform.up * randomForceUp, ForceMode.Impulse);
            rb.AddForce(transform.forward * randomForceForward, ForceMode.Impulse);

            water.Play();
        }
    }

}
