using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsHandler : MonoBehaviour
{
    public Door[] Doors;

    private void Start()
    {
        Doors[0].OnTouchDoor += (GameObject gameObject) => teleportToDoor(gameObject, 0, 1);
        Doors[1].OnTouchDoor += (GameObject gameObject) => teleportToDoor(gameObject, 1, 0);
    }

    private void teleportToDoor(GameObject gameObject, int start, int dest)
    {
        if (Doors[start].teleportEnable && !Doors[start].isDestination)
        {
            gameObject.transform.position = Doors[dest].transform.position;
            Doors[dest].teleportEnable = false;
        }
    }
}
