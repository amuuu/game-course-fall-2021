using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UIManager : MonoBehaviour
{
    public Timer timer;
    public Text heartCounterText;
    public Text scoreText;
    public int score = 0;
    public int hearts = 0;

    public void Start()
    {
        timer.OnFinishTime += () => onFinishTime();
    }

    public void onHeartComboConsume()
    {
        hearts += 1;
        heartCounterText.text = hearts.ToString();
    }

    public void onTimeFreezerConsume()
    {
        timer.enableFreezeTime();
    }

    public void onRottenConsume()
    {
        hearts -= 1;
        heartCounterText.text = hearts.ToString();

        timer.decreaseTime(3);
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
