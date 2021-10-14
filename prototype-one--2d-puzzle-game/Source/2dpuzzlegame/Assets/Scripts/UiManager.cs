using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text collectedKeysCounterText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyPickup.AddListener(UpdateCollectedKeysCounterText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }
    public void UpdateCollectedKeysCounterText()
    {
        Debug.Log("UPDATE keys count");
        int newTextValue = int.Parse(collectedKeysCounterText.text) + 1;
        collectedKeysCounterText.text = newTextValue.ToString();
    }
}
