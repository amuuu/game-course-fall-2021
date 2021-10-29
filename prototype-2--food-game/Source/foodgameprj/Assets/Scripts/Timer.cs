using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public float time = 10;
    public Text timerText;
    public Action OnFinishTime;

    public float freezeTime = 5;
    public bool isFeezed = false;


    // Update is called once per frame
    void Update()
    {
        if (isFeezed)
        {
            if(freezeTime > 0)
            {
                freezeTime -= Time.deltaTime;
            }
            else
            {
                isFeezed = false;
                timerText.color = Color.white;
            }
        }
        else
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                OnFinishTime.Invoke();
                time = 0;
            }

            if(time < 10)
            {
                timerText.color = Color.red;
            }

            int sec = (int)time % 60;
            int min = (int)time / 60;

            string secondDisplay = sec.ToString();
            if (sec < 10)
            {
                secondDisplay = '0' + sec.ToString();
            }

            timerText.text = min.ToString() + ":" + secondDisplay;
        }
    }

    public void enableFreezeTime()
    {
        isFeezed = true;
        timerText.color = Color.blue;
    }

    public void decreaseTime(float amount)
    {
        if(time < 4)
        {
            time = 0;
        }
        else
        {
            time -= amount;
        }
    }
}
