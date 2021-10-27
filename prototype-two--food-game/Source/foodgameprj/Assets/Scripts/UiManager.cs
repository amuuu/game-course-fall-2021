using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    Text heartsCount;
    Text scoreCount;
    Text gameResult;

    void Awake()
    {
        heartsCount = transform.Find("HeartsCounterText").GetComponent<Text>();
        scoreCount = transform.Find("ScoreCountCounterText").GetComponent<Text>();
        gameResult = transform.Find("GameResultText").GetComponent<Text>();
    }

    public void UpdateHeartsCount(int value)
    {
        heartsCount.text = value.ToString();
    }
    public void UpdateScoreCount(int value)
    {
        scoreCount.text = value.ToString();
    }
    public void ShowWinText()
    {
        gameResult.text = "YOU WON";
        gameResult.color = Color.green;
        gameResult.gameObject.SetActive(true);
    }
    public void ShowLoseText()
    {
        gameResult.text = "YOU LOST";
        gameResult.color = Color.red;
        gameResult.gameObject.SetActive(true);
    }
}
