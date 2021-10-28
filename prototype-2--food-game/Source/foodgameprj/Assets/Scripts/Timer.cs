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


    // Update is called once per frame
    void Update()
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

        int sec = (int)time % 60;
        int min = (int)time / 60;

        string secondDisplay = sec.ToString();
        if(sec < 10)
        {
            secondDisplay = '0' + sec.ToString();
        }

        timerText.text = min.ToString() +":"+ secondDisplay;
    }
}
