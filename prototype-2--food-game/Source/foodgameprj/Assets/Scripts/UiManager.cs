using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Text heartCountText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.updateScore.AddListener(UpdateScoreText);
        eventSystem.updateHeartCount.AddListener(UpdateHeartCountText);
    }

    public void UpdateScoreText()
    {
        //int newScore = int.Parse(scoreText.text.Split(' ')[1]) + 250;
        scoreText.text = "Score: " + eventSystem.playrScore;
    }

    public void UpdateHeartCountText()
    {
        int newHeartCount = int.Parse(heartCountText.text.Split(' ')[1]) - 1;
        if (newHeartCount < 2)
        {
            heartCountText.color = Color.red;
        }
        heartCountText.text = "Hearts: " + newHeartCount.ToString();
    }
}
