﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnPlayerScoreUpdate;

    void Awake()
    {
        OnPlayerScoreUpdate = new UnityEvent();
    }

    void Update()
    {
        
    }
}
