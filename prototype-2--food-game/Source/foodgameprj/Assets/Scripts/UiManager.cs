using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text score;
    public Text heart;
    public EventSystemCustom eventSystem;

    public FoodItemConfig config;

    void Start()
    {
        eventSystem.OnIncreaseScore.AddListener(UpdateScoreText);
        eventSystem.OnGainHeart.AddListener(UpdateHeartText);
        eventSystem.OnDecreaseScore.AddListener(DegradeScoreText);
        eventSystem.OnLoseHeart.AddListener(DegradeHeartText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(score.text) + 1;
        score.text = newTextValue.ToString();
    }

    public void UpdateHeartText()
    {
        Debug.Log("UPDATE HEART");
        int newTextValue = int.Parse(heart.text) + config.score;
        heart.text = newTextValue.ToString();
    }

    public void DegradeScoreText()
    {
        Debug.Log("DEGRADE SCORE");
        int newTextValue = int.Parse(score.text) - 1;
        score.text = newTextValue.ToString();
    }

    public void DegradeHeartText()
    {
        Debug.Log("DEGRADE HEART");
        int newTextValue = int.Parse(heart.text) - 1;
        heart.text = newTextValue.ToString();
    }
}
