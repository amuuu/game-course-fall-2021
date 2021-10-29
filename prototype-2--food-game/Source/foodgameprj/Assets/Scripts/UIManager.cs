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
    public Text finishStateText;
    public GameObject backGround;
    public int score = 0;
    public int hearts = 0;

    public FoodPlacer FoodPlacer;
    public PlayerController playerController;

    public void Start()
    {
        backGround.SetActive(false);
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
        if(hearts == 0)
        {
            finishStateText.text = "  You Died!";
            backGround.SetActive(true);
            timer.stopTime();
            finishGame();
            return;
        }

        hearts -= 1;
        heartCounterText.text = hearts.ToString();

        timer.decreaseTime(3);
    }

    public void finishGame()
    {
        playerController.finishGame = true;
        FoodPlacer.finishGame = true;
    }


    private void onFinishTime()
    {
        finishStateText.text = "Time Is Up!";
        backGround.SetActive(true);
        finishGame();
    }

    public void onCollectFood(FoodItemConfig foodItemConfig)
    {
        score += foodItemConfig.score;
        scoreText.text = "score: " + score.ToString();

        timer.increaseTime((int)foodItemConfig.weight);
    }

}
