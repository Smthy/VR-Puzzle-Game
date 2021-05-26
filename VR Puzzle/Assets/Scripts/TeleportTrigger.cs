using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform player, teleporterPad;

    private void OnTriggerEnter(Collider other)     //if the player hits this area, they will be teleported away
    {
        if(other.CompareTag("Player"))
        {
            player.position = teleporterPad.position;
        }
    }
}
