using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTeleport : MonoBehaviour
{
    private GameObject key;
    private bool haveKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(key)
            {
                key.SetActive(false);
                haveKey = true;
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.KeyTele.ToString()))
        {
            // collision.gameObject.SetActive(false);
            key = null;
            EventSystemCustom.current.onHintChange.Invoke("");
        }
    }
}
