using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSwitch : MonoBehaviour
{
    public EventSystemCustom eventSystem;
    bool playerIsNearby;
    // Start is called before the first frame update
    void Start()
    {
        playerIsNearby = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsNearby)
        {
            Debug.Log("SWITCH");
            eventSystem.OnCloneSwitchMode.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            playerIsNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            playerIsNearby = false;
        }
    }
}
