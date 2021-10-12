using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //public Text counterText;
    public Text KeyCounter;
    public Text WinLabel;
    public Text LostLabel;
    public EventSystemCustom eventSystem;

    void Start()
    {
        //eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnCharacterEatKey.AddListener(UpdateKeyScore);
        eventSystem.OnGameEndedWon.AddListener(EndGameWon);
        eventSystem.OnGameEndedLost.AddListener(EndGameLost);
    }

    //public void UpdateScoreText()
    //{
    //    Debug.Log("UPDATE SCORE");
    //    int newTextValue = int.Parse(counterText.text) + 1;
    //        counterText.text = newTextValue.ToString();
    //}

    public void UpdateKeyScore()
    {
        //Debug.Log("UPDATE KEY SCORE");
        int newTextValue = int.Parse(KeyCounter.text) + 1;
        KeyCounter.text = newTextValue.ToString();
    }

    public void EndGameWon()
    {
        if (int.Parse(KeyCounter.text) >= Constants.RequiredKeyCountToWin)
        {
            //Debug.Log("YOU WON!");
            WinLabel.text = "You Won!";
        }
    }

    public void EndGameLost()
    {
        LostLabel.text = "You Lost!";
    }
}
