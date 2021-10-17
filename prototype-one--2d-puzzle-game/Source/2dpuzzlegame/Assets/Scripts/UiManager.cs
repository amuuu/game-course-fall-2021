﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyCounterText;
    public Text statusText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnPlayerKeyCollect.AddListener(UpdateKeyCounterText);
        eventSystem.OnPlayerWin.AddListener(ShowWinText);
        eventSystem.OnPlayerLose.AddListener(ShowLoseText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateKeyCounterText()
    {
        int newTextValue = int.Parse(keyCounterText.text) + 1;
        keyCounterText.text = newTextValue.ToString();
    }

    public void ShowWinText()
    {
        statusText.text = "You Won!";
    }

    public void ShowLoseText()
    {
        statusText.text = "You Lost!";
    }
}
