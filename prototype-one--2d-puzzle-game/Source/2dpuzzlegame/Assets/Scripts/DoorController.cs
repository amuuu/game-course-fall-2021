using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public int NumberOfKeysNeeded;
    public EventSystemCustom eventSystem;
    public TextMesh KeysNeededText;
    public SpriteRenderer KeyIcon;
    // Start is called before the first frame update
    void Start()
    {
        KeysNeededText.text = NumberOfKeysNeeded.ToString();
        eventSystem.OnKeyPickup.AddListener(UpdateKeysNeededColor);
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
            eventSystem.OnDoorOpened.Invoke();
            return true;
        }
        Debug.Log("keys not enough!");
        return false;
    }

    //method to show needed keys count on top of door
    void UpdateKeysNeededColor(int keyCount){
        if(keyCount >= NumberOfKeysNeeded){
            KeysNeededText.color = Color.green;
            KeyIcon.color = Color.green;
        }
        else{
            KeysNeededText.color = Color.red;
            KeyIcon.color = Color.red;
        }
    }
}
