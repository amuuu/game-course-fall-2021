using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public PlayerController player;
    public Text healthText;
    public Text scoreText;
    public Text gameOverText;
    public Text gameOverDesText;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        gameOverDesText.gameObject.SetActive(false);

        UpdateHealthText();
        UpdateScoreText();

        // Add listeners 
        eventSystem.onBoardScoresChanged.AddListener(UpdateHealthText);
        eventSystem.onBoardScoresChanged.AddListener(UpdateScoreText);
        eventSystem.onGameOver.AddListener(ShowGameOver);
    }

    private void UpdateHealthText()
    {
        healthText.text = "❤️ " + player.playerHealth;
    }


    private void UpdateScoreText()
    {
        scoreText.text = "⊙ " + player.playerScore;
    }

    private void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverDesText.gameObject.SetActive(true);
    }
}