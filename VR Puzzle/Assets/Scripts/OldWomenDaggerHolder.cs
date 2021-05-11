using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldWomenDaggerHolder : MonoBehaviour
{
    public Text text;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Dagger"))
        {
            text.text = ("Well Done, here is your potion!");
        }
    }
}
