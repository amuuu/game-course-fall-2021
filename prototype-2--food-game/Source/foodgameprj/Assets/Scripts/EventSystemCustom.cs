using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnEatFood;
    public UnityEvent onHeartLost;
    public UnityEvent onHeartIncrease;

    void Awake()
    {
        OnEatFood = new UnityEvent();
        onHeartLost = new UnityEvent();
        onHeartIncrease = new UnityEvent();
    }
}