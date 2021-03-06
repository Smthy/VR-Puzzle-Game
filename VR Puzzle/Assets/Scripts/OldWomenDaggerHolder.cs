using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldWomenDaggerHolder : MonoBehaviour
{
    public Text text;

    public GameObject WaterBreathing;

    private void Start()
    {
        WaterBreathing.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Dagger"))
        {
            text.text = ("Well Done, here is your potion!");            //if the dagger is placed in the Unity XR Socket, it will active this.
            WaterBreathing.SetActive(true);
        }
    }
}
