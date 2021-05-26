using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketInventory : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void FixedUpdate()
    {
        //Setting the offset of inventory, however it has been changed to the wrist inventory

        transform.position = player.position + Vector3.up * offset.y + Vector3.ProjectOnPlane(player.right, Vector3.up).normalized * offset.x + Vector3.ProjectOnPlane(player.forward, Vector3.up).normalized * offset.z;
    }
}
