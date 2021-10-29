using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyNumberText;          // Reference to key number text in UI
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.onGetKey.AddListener(UpdateKeyNumberText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    // Update key number text in UI
    public void UpdateKeyNumberText()
    {
        int newKeyValue = int.Parse(keyNumberText.text) + 1;
        keyNumberText.text = newKeyValue.ToString();
    }
}
