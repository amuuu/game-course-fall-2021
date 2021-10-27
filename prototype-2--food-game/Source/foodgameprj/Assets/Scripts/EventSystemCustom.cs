using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent HeartCounterIncrease;
    public UnityEvent HeartCounterDecrese;
    void Awake()
    {
        HeartCounterIncrease = new UnityEvent();
        HeartCounterDecrese = new UnityEvent();
    }
}