using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameSystem : MonoBehaviour
{
    public GameObject endParticles;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Staff"))
        {
            Instantiate(endParticles, transform);

            SceneManager.LoadScene("End Scene");
        }
    }
}
