using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text winText;
    public EventSystemCustom eventSystem;
    public WinEventManager winEvent;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        winEvent.OnExitDoorWin.AddListener(ShowWinText);
        winEvent.OnDeathZoneLose.AddListener(ShowLoseText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void ShowWinText()
    {
        winText.text = "You Win!";
    }

    public void ShowLoseText()
    {
        winText.text = "You Lose!";
    }
}
