using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTeleport : MonoBehaviour
{
    private GameObject key;
    private GameObject doorSource;
    private bool haveKey = false;
    [SerializeField] GameObject doorDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(key != null)
            {
                key.SetActive(false);
                key = null;
                haveKey = true;
            }
            else if (doorSource != null)
            {
                transform.position = doorDestination.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.KeyTele.ToString()))
        {
            // collision.gameObject.SetActive(false);
            key = collision.gameObject;
            EventSystemCustom.current.onHintChange.Invoke("Press E to collect");
        }
        else if (collision.gameObject.CompareTag(TagNames.DoorTeleS.ToString()))
        {
            if (haveKey)
            {
                doorSource = collision.gameObject;
                EventSystemCustom.current.onHintChange.Invoke("Press E to teleport");
            }
            else
            {
                EventSystemCustom.current.onHintChange.Invoke("You need purple key.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.KeyTele.ToString()))
        {
            // collision.gameObject.SetActive(false);
            key = null;
            EventSystemCustom.current.onHintChange.Invoke("");
        }
        else if (collision.gameObject.CompareTag(TagNames.DoorTeleS.ToString()))
        {
            doorSource = null;
            EventSystemCustom.current.onHintChange.Invoke("");
        }
    }
}
