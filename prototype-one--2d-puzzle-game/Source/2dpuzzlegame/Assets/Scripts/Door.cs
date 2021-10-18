using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public Action<GameObject> OnTouchDoor;
    public bool isDestination;
    public Boolean teleportEnable = true;
    public Game game;
    private GameObject player = null;

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && game.collectedKeys > 0 && player != null)
        {
            OnTouchDoor.Invoke(player);
            game.onKeyUsed();
            player = null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()) && game.collectedKeys > 0)
        {
            player = collision.gameObject;
        }

        if (collision.gameObject.CompareTag(TagNames.Clone.ToString()))
        {
            OnTouchDoor.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            teleportEnable = true;
        }
    }
}
