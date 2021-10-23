using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnEatFood;
    public UnityEvent onHeartLost;

    void Awake()
    {
        OnEatFood = new UnityEvent();
        onHeartLost = new UnityEvent();
    }
}