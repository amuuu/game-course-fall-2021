﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter, 
        OnAccquiredKey, OnCharacterNearObjectEnter, OnCharacterNearObjectExit,  // Key 
        OnCharSwtchEnter, OnCharSwtchExit,                                      // Character switch
        OnCharacterExitDoorEnter, OnCharacterExitDoorExit,                      // Exit door 
        OnWon, OnLost                                                           // Finished game 
        ;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();

        OnAccquiredKey = new UnityEvent();
        OnCharacterNearObjectEnter = new UnityEvent();
        OnCharacterNearObjectExit = new UnityEvent();

        OnCharSwtchEnter = new UnityEvent();
        OnCharSwtchExit = new UnityEvent();

        OnCharacterExitDoorEnter = new UnityEvent();
        OnCharacterExitDoorExit = new UnityEvent();

        OnWon = new UnityEvent();
        OnLost = new UnityEvent();
    }
}
