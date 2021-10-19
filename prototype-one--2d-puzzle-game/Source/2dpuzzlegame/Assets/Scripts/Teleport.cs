using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;

    public PlayerMove player;

    private void Update()
    {
        // E to teleport for main character
        if (Input.GetKey(KeyCode.E) && player.isNearTeleportSource != null && player.hasTeleportKey)
        {
            player.gameObject.transform.position = destination.gameObject.transform.position;
        }

        // E to teleport for clones
        foreach (var cloneMove in player.cloneMoves)
        {
            if (cloneMove.isNearTeleport)
            {
                cloneMove.transform.position = destination.gameObject.transform.position;
            }
        }
    }
}