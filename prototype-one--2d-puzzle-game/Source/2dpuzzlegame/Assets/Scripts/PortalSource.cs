using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSource : MonoBehaviour
{
    public EventSystemCustom eventSystem;
    public GameObject player;
    public GameObject destination;
    bool playerIsNearby;
    // Start is called before the first frame update
    void Start()
    {
        playerIsNearby = false;
        eventSystem.OnPlayerTeleport.AddListener(TeleportPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsNearby)
        {
            eventSystem.OnPortalInteract.Invoke();
        }
    }

    void TeleportPlayer()
    {
        if (playerIsNearby)
            player.transform.position = destination.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            player = collision.gameObject;
            playerIsNearby = true;
        }
        else if (collision.gameObject.CompareTag(TagNames.Clone.ToString()))
        {
            collision.gameObject.transform.position = destination.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            player = null;
            playerIsNearby = false;
        }
    }
}
