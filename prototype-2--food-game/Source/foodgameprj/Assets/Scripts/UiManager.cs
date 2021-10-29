using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text heartText;

    public EventSystemCustom eventSystem;



    void Start()
    {
        eventSystem.ScoreEvent.AddListener(UpdateScoreText);
        eventSystem.HeartCountEvent.AddListener(UpdateHeart);

    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        GameObject thePlayer = GameObject.Find("Player");
        PlayerController player = thePlayer.GetComponent<PlayerController>();
        counterText.text = player.playerScore.ToString();
    }

    public void UpdateHeart()
    {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerController player = thePlayer.GetComponent<PlayerController>();
        heartText.text = player.playerHeartsCount.ToString();
    }
}