using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public PlayerController playerController;

    public Text scoreValueText;

    void Start()
    {
        eventSystem.OnPlayerScoreUpdate.AddListener(UpdateScoreText);
    }

    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        scoreValueText.text = playerController.playerScore.ToString();
    }
}
