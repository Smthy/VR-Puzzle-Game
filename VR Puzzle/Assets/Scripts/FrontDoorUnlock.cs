using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorUnlock : MonoBehaviour
{
    public GameObject lock1, lock2, door, boss, finalKey;

    private void Start()
    {
        door.SetActive(true);
        boss.SetActive(false);
        finalKey.SetActive(false);
    }

    private void Update()
    {
        if(!lock1.activeInHierarchy && !lock2.activeInHierarchy)        //Checks if the locks are active, if not will spawn in the final enemy
        {
            door.SetActive(false);
            boss.SetActive(true);
            finalKey.SetActive(true);
        }
    }
}
