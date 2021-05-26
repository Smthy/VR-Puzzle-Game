using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public GameObject lock1, door;

    void Update()       //Checks if the lock is active, if so it will remain locked
    {
        if (!lock1.activeInHierarchy)
        {
            door.SetActive(false);
        }
    }
}
