using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLock : MonoBehaviour
{
    public GameObject keyhold;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Key"))
        {
            keyhold.SetActive(false);
        }

    }
}
