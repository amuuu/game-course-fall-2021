using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int NumberOfKeysNeeded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool OpenDoor(int keysCount){
        Debug.Log(string.Format("need {0} keys to open the door",NumberOfKeysNeeded));

        if (keysCount >= NumberOfKeysNeeded){
            Debug.Log("door opened");
            //invoke event to show win text
            return true;
        }
        Debug.Log("keys not enough!");
        return false;
    }

    //method to show needed keys count on top of door
}
