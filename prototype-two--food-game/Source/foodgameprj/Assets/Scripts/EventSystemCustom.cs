using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnPlayerScoreUpdate;
    public UnityEvent OnPlayerHeartCountUpdate;

    void Awake()
    {
        OnPlayerScoreUpdate = new UnityEvent();
        OnPlayerHeartCountUpdate = new UnityEvent();
    }

    void Update()
    {
        
    }
}
