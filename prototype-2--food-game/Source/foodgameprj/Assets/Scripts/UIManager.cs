using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text RemainingTime;
    public Text Heart;
    public Text Score;
    public EventSystemCustomScript eventSystem;

    void Start()
    {
        eventSystem.OnEatFood.AddListener(UpdateScoreText);
        eventSystem.OnDecreaseHeart.AddListener(UpdateHeartText);
        eventSystem.OnUpdateRemainingTime.AddListener(UpdateRemainingTime);
        //eventSystem.OnGameEndedWon.AddListener(UpdateRemainingTime);
        //eventSystem.OnGameEndedLost.AddListener(EndGameLost);
    }

    public void UpdateScoreText()
    {
        //Debug.Log("UPDATE SCORE");
        int NewScore =  GameObject.Find("Player").GetComponent<PlayerController>().playerScore;
        Score.text = NewScore.ToString();
    }

    public void UpdateHeartText()
    {
        //Debug.Log("UPDATE KEY SCORE");
        int NewHeartCount = GameObject.Find("Player").GetComponent<PlayerController>().playerHeartsCount;
        Heart.text = NewHeartCount.ToString();
    }

    public void UpdateRemainingTime()
    {
        double time = GameObject.Find("Player").GetComponent<PlayerController>().timeRemaining;
        RemainingTime.text = ((int)time).ToString();
    }

    //public void EndGameWon()
    //{
    //    if (int.Parse(KeyCounter.text) >= Constants.RequiredKeyCountToWin)
    //    {
    //        //Debug.Log("YOU WON!");
    //        WinLabel.text = "You Won!";
    //    }
    //}

    //public void EndGameLost()
    //{
    //    LostLabel.text = "You Lost!";
    //}
}