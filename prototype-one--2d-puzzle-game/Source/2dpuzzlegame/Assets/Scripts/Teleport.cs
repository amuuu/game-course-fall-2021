using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public Transform destination;
    public bool destinationDoor;
    //void Start()
    //{
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (FindObjectOfType<PlayerMove>().teleportPermission && FindObjectOfType<UiManager>().telKey )
            {
                FindObjectOfType<PlayerMove>().gameObject.transform.position = destination.position;
            }
        }
    }
}
