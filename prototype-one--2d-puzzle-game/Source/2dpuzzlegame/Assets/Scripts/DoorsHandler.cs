using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsHandler : MonoBehaviour
{
    public Door[] Doors;
    public GameObject Player;

    private void Start()
    {
        Doors[0].OnTouchDoor += () => teleportToDoor(0,1);
        Doors[1].OnTouchDoor += () => teleportToDoor(1,0);
    }

    private void teleportToDoor(int start, int dest)
    {
        if (Doors[start].teleportEnable)
        {
            Player.transform.position = Doors[dest].transform.position;
            Doors[dest].teleportEnable = false;
        }
    }
}
