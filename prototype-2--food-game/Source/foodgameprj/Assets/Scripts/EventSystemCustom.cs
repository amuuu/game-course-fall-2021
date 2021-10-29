using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent ScoreEvent;
    public UnityEvent HeartCountEvent;

    void Awake()
    {
        ScoreEvent = new UnityEvent();
        HeartCountEvent = new UnityEvent();
    }
}
