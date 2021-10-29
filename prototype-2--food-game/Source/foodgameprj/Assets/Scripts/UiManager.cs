using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text score;
    public Text heart;

    public EventSystemCustom eventSystem;

    public PlayerController player;

    void Start()
    {
        eventSystem.OnScore.AddListener(UpdateScoreText);
        eventSystem.OnIncreaseHeart.AddListener(UpdateIncreaseHeartText);
        eventSystem.OnDecreaseHeart.AddListener(UpdateDecreaseHeartText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        score.text = player.playerScore.ToString();
    }

    public void UpdateIncreaseHeartText()
    {
        Debug.Log("UPDATE HEART");
        int value = int.Parse(heart.text) + 1;
        heart.text = value.ToString();
    }

    public void UpdateDecreaseHeartText()
    {
        Debug.Log("UPDATE HEART");
        int value = int.Parse(heart.text) - 1;
        heart.text = value.ToString();
    }

}
