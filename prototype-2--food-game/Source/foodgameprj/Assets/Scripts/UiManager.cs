using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text score;
    public Text heart;
    public Text lose;

    public EventSystemCustom eventSystem;

    public PlayerController player;

    void Awake()
    {
        heart.text = player.playerHeartsCount.ToString();
    }

    void Start()
    {
        eventSystem.OnScore.AddListener(UpdateScoreText);
        eventSystem.OnIncreaseHeart.AddListener(UpdateIncreaseHeartText);
        eventSystem.OnDecreaseHeart.AddListener(UpdateDecreaseHeartText);
        eventSystem.YouLost.AddListener(YouLostText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        score.text = player.playerScore.ToString();
    }

    public void UpdateIncreaseHeartText()
    {
        Debug.Log("UPDATE HEART");
        player.playerHeartsCount += 1;

        heart.text = player.playerHeartsCount.ToString();

    }

    public void UpdateDecreaseHeartText()
    {
        Debug.Log("UPDATE HEART");
        player.playerHeartsCount -= 1;

        heart.text = player.playerHeartsCount.ToString();
    }

    public void YouLostText()
    {
        Debug.Log("YOU LOST");
        lose.text = "YOU LOST!";
    }

}
