using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoorManager : MonoBehaviour
{
    public GameObject otherDoor;
    public GameObject player;
    public bool isTeleportKeyStolen;

    private void Start()
    {
        isTeleportKeyStolen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player)
            {
                player.transform.position = otherDoor.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            {
                if (isTeleportKeyStolen)
                    player = collision.gameObject;
            }
        }
        else
        {
            collision.gameObject.transform.position = otherDoor.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            player = null;
        }
    }
}
