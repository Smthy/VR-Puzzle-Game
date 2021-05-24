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
        endLight.intensity = Mathf.PingPong(Time.time, timer);
    }  
}
