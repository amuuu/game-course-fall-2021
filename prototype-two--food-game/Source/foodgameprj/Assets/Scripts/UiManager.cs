using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Text heartText;

    public EventSystemCustom eventSystem;

    public PlayerController player;

    void Start()
    {
        eventSystem.OnHeartDecreaserEnter.AddListener(UpdateHeartText);
        eventSystem.OnFoodToPlateEnter.AddListener(UpdateScoreText);
    }

    public void UpdateHeartText()
    {
        string[] tokens = heartText.text.Split(' ');
        int newKeyValue = player.playerHeartsCount;
        heartText.text = tokens[0] + ' ' + tokens[1] + ' ' + newKeyValue;
    }

    public void UpdateScoreText()
    {
        string[] tokens = scoreText.text.Split(' ');
        int newKeyValue = player.playerScore;
        scoreText.text = tokens[0] + ' ' + tokens[1] + ' ' + newKeyValue;
    }
}
