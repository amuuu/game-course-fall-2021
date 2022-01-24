using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowDoor : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public bool source;
    private bool touchDoor;
    private bool cloneTouchDoor;
    private GameObject cloneEntered;
    public GameObject DestionationDoor;
    private int keyCount;
    public GameObject user;

    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
        touchDoor = false;
        keyCount = 0;
        eventSystem.OnEatYellowKeyEvent.AddListener(keyEated);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (source)
            {
                Debug.Log("source");
                Debug.Log(touchDoor);
                Debug.Log(keyCount);
                if (touchDoor && keyCount == 1)
                {
                    Debug.Log("sdadadadsad");
                    user.transform.position = new Vector3(DestionationDoor.transform.position.x,
                        DestionationDoor.transform.position.y,
                        user.transform.position.z);
                }

            }
        }
        if (source && cloneTouchDoor)
        {
            Debug.Log("clone entered");
            cloneEntered.transform.position = new Vector3(DestionationDoor.transform.position.x,
                DestionationDoor.transform.position.y,
                cloneEntered.transform.position.z);
        }
    }

    private void keyEated()
    {
        Debug.Log("keeyy");
        keyCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("User"))
            touchDoor = true;

        if (collision.gameObject.CompareTag($"Clone"))
        {
            Debug.Log("umad");
            cloneTouchDoor = true;
            cloneEntered = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("User"))
            touchDoor = false;

        if (collision.gameObject.CompareTag($"Clone"))
        {
            cloneTouchDoor = false;
            cloneEntered = null;
        }
    }
}