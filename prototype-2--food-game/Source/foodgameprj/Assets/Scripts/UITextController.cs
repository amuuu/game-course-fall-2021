using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController : MonoBehaviour
{
    public Text HeartCounterText;
    public Text ScoreText;
    public EventSystemCustom eventSystem;
    void Start()
    {
        eventSystem.HeartCounterIncrease.AddListener(HeartCounterIncrease);
        eventSystem.HeartCounterDecrese.AddListener(HeartCounterDecrease);
    }
    public void HeartCounterIncrease()
    {
        int newValue = int.Parse(HeartCounterText.text) + 1;
        HeartCounterText.text = newValue.ToString();
        Debug.Log("Heart counter text : " + HeartCounterText.text);
    }
    public void HeartCounterDecrease()
    {
        int newValue = int.Parse(HeartCounterText.text) - 1;
        HeartCounterText.text = newValue.ToString();
        Debug.Log("Heart counter text : " + HeartCounterText.text);
    }
}
