using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keysCounterText;
    public Text WonOrLostText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyCollected.AddListener(UpdateKeysCollectedText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateKeysCollectedText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(keysCounterText.text) + 1;
        keysCounterText.text = newTextValue.ToString();
        Debug.Log(keysCounterText.text);
    }

    public void UpdateWonOrLostTextText(bool won)
    {
        if (won)
        {
            WonOrLostText.text = "YOU WON";
        }
        else
        {
            WonOrLostText.text = "YOU LOST";

        }
        Debug.Log(WonOrLostText.text);
    }
}
