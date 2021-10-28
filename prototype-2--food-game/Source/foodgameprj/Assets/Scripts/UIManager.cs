using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Timer timer;
    public Text heartCounterText;
    public Text scoreText;
    public int score = 0;

    public void Start()
    {
        timer.OnFinishTime += () => onFinishTime();
    }

    private void onFinishTime()
    {
        Debug.Log("FINISH");
    }

    public void onCollectFood(FoodItemConfig foodItemConfig)
    {
        score += foodItemConfig.score;
        scoreText.text = "score: " + score.ToString();
    }

}
