using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnHeartDecreasePlayerScore, OnHeartDecreaseUIUpdate,       // Decrease heart
        OnScoreUpdate;

    void Awake()
    {
        OnHeartDecreasePlayerScore = new UnityEvent();
        OnHeartDecreaseUIUpdate = new UnityEvent();

        OnScoreUpdate = new UnityEvent();
    }
}
