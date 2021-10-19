using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text KeyText;
    public Text WinText;
    public Text LoseText;

    public EventSystemCustom eventSystem;
   
    

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnCollectedKeysEvent.AddListener(UpdateCollectedKey);
        eventSystem.OnWinDoorEvent.AddListener(UpdateWinDoor);
        eventSystem.OnDeathZoneEvent.AddListener(UpdateLose);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateCollectedKey()
    {
        Debug.Log("UPDATE collectedKey");
        int newTextValue = int.Parse(KeyText.text) + 1;
        KeyText.text = newTextValue.ToString();
    }

    public void UpdateWinDoor()
    {
        Debug.Log("UPDATE Won");
        WinText.text = "You Won!";
    }

   
        public void UpdateLose()
    {
        Debug.Log("UPDATE Lose");
        LoseText.text = "You Lost!";
    }
}
