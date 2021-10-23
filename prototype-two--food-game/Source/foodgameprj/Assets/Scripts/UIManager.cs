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

    void Start()
    {
        UpdateHealthText();

        // Add listeners 
        eventSystem.onBoardScoresChanged.AddListener(UpdateHealthText);
    }

    private void UpdateHealthText()
    {
        healthText.text = "❤️ " + player.playerHealth;
    }
}