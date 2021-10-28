using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnHeartDecreaseCollected;
    public UnityEvent OnHeartIncreaseCollected;
    void Awake()
    {
        OnHeartDecreaseCollected = new UnityEvent();
        OnHeartIncreaseCollected = new UnityEvent();
    }
}
