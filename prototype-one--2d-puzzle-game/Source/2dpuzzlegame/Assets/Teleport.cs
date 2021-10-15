using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportDoorDist;

    public GameObject Player;
    public GameObject destinationDoor;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distFromTeleDoor = Vector3.Distance(Player.transform.position, transform.position);
            if (distFromTeleDoor < teleportDoorDist)
            {

                Debug.Log("Here near the source teleport door");
            }
        }
    }
}
