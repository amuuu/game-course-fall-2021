using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText, keyCounterText;
    public EventSystemCustom eventSystem;
    public GameObject pickupMessagePanel, activateMessagePanel;
    public PlayerMove mainCharacter;

    void Start()
    {
        UnityEngine.Events.UnityAction OpenPickupMessagePanel = () => pickupMessagePanel.SetActive(true);
        UnityEngine.Events.UnityAction ClosePickupMessagePanel = () => pickupMessagePanel.SetActive(false);

        UnityEngine.Events.UnityAction OpenActivateMessagePanel = () => activateMessagePanel.SetActive(true);
        UnityEngine.Events.UnityAction CloseActivateMessagePanel = () => activateMessagePanel.SetActive(false);

        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);

        eventSystem.OnCharacterNearObjectEnter.AddListener(OpenPickupMessagePanel);
        eventSystem.OnCharacterNearObjectExit.AddListener(ClosePickupMessagePanel);
        eventSystem.OnAccquiredKey.AddListener(UpdateKeyText);

        eventSystem.OnCharacterExitDoorEnter.AddListener(OpenActivateMessagePanel);
        eventSystem.OnCharacterExitDoorExit.AddListener(CloseActivateMessagePanel);
    }

    private void UpdateKeyText()
    {
        keyCounterText.text = "Collected " + mainCharacter.accquiredKeys.ToString() + " keys";
    }

    public void UpdateScoreText()
    {
        int newTextValue = int.Parse(Regex.Match(counterText.text, @"\d+").Value) + 1;
            counterText.text = "Clone mfs touched the sticky platform " + newTextValue.ToString() + " times";
    }
}
