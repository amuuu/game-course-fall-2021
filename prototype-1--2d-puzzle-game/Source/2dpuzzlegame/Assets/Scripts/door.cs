using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    private bool touchDoor;
    public GameObject WinMenu;
    public GameObject Level;
    public EventSystemCustom eventSystem;
    private int keyEated;
    void Start()
    {
        eventSystem.OnEatKeyEvent.AddListener(UpdateKeyEat);
        keyEated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (touchDoor)
            {
                if (keyEated == 3)
                {
                    WinMenu.SetActive(true);
                    Level.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("User"))
        {
            touchDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("User"))
        {
            touchDoor = false;
        }
    }
    public void UpdateKeyEat()
    {
        keyEated++;
    }
}
