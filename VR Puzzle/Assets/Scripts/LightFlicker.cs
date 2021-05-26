using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light endLight;
    public int timer = 5;
    private void Start()
    {
        endLight = GetComponent<Light>();
    }

    private void Update()
    {
        endLight.intensity = Mathf.PingPong(Time.time, timer);      //Uses the maths tool to push the intensity of the light from 0 to the set number
    }  
}
