using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText, keyCounterText, messagePanelText;
    public EventSystemCustom eventSystem;
    public GameObject messagePanel;
    public PlayerMove mainCharacter;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OneCharacterNearObjectEnter.AddListener(OpenMessagePanel);
        eventSystem.OneCharacterNearObjectExit.AddListener(CloseMessagePanel);
        eventSystem.OnAccquiredKey.AddListener(UpdateKeyText);
    }

    private void UpdateKeyText()
    {
        //Debug.Log("UPDATE KEYS");
        keyCounterText.text = "Collected " + mainCharacter.accquiredKeys.ToString() + " keys";
    }

    public void UpdateScoreText()
    {
        //Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(Regex.Match(counterText.text, @"\d+").Value) + 1;
            counterText.text = "Clone mfs touched the sticky platform " + newTextValue.ToString() + " times";
    }

    public void OpenMessagePanel()
    {
        messagePanel.SetActive(true);
    }

    public void CloseMessagePanel()
    {
        messagePanel.SetActive(false);
    }
}
