using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public PlayerController playerController;

    public Text scoreValueText;
    public Text heartCountText;
    public Text loseText;

    void Start()
    {
        eventSystem.OnPlayerScoreUpdate.AddListener(UpdateScoreText);
        eventSystem.OnPlayerHeartCountUpdate.AddListener(UpdateHeartText);
        eventSystem.OnPlayerLose.AddListener(ShowPlayerLoseText);
    }

    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        scoreValueText.text = playerController.playerScore.ToString();
    }

    public void UpdateHeartText()
    {
        heartCountText.text = playerController.playerHeartsCount.ToString();
    }

    public void ShowPlayerLoseText()
    {
        loseText.text = "You Lost!";
    }
}
