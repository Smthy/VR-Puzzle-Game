using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinalKey : MonoBehaviour
{
    public GameObject keyhold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalKey"))
        {
            keyhold.SetActive(false);
        }

    }
}
