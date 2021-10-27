using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public bool isSource;
    private bool isKeyCollect;
    private bool inDoorArea;
    private bool cloneinDoorArea;
    private GameObject cloneEntered;
    public GameObject DestionationDoor;

    // Start is called before the first frame update
    void Start()
    {
        isKeyCollect = false;
        eventSystem.OnTeleportKeyCollected.AddListener(TeleportKeyCollected);
        inDoorArea = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("InDoorArea");
            Debug.Log(inDoorArea);
            Debug.Log("IsSource");
            Debug.Log(isSource);
            Debug.Log("isKeyCollect");
            Debug.Log(isKeyCollect);
            if (inDoorArea && isSource && isKeyCollect)
            {
                eventSystem.PlayerShouldTeleport.Invoke();
            }
        }

        if (cloneinDoorArea && isSource)
        {
            var DestinationDoorPosition = DestionationDoor.transform.position;
            cloneEntered.transform.position = new Vector3(DestinationDoorPosition.x, DestinationDoorPosition.y,
                cloneEntered.transform.position.z);
        }
    }

    private void TeleportKeyCollected()
    {
        Debug.Log("Keeeeeey umad");
        isKeyCollect = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            inDoorArea = true;
        }

        if (collision.gameObject.CompareTag(TagNames.Clone.ToString()))
        {
            cloneinDoorArea = true;
            cloneEntered = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            inDoorArea = false;
        }

        if (collision.gameObject.CompareTag(TagNames.Clone.ToString()))
        {
            cloneinDoorArea = false;
            cloneEntered = null;
        }
    }
}