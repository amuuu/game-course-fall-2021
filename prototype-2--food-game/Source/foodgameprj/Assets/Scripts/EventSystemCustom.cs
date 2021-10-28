using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent GetFoodScoreCount;
    public UnityEvent GetHeartsCount;
    public UnityEvent GameOver;

    void Awake()
    {
        GetFoodScoreCount = new UnityEvent();
        GetHeartsCount = new UnityEvent();
        GameOver = new UnityEvent();
    }
}
