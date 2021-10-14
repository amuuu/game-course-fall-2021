using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter, 
        OnAccquiredKey, OnCharacterNearObjectEnter, OnCharacterNearObjectExit,  //key logic
        OnCharacterExitDoorEnter, OnCharacterExitDoorExit,                       //exit door logic
        OnFinishedLevel
        ;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();

        OnAccquiredKey = new UnityEvent();
        OnCharacterNearObjectEnter = new UnityEvent();
        OnCharacterNearObjectExit = new UnityEvent();

        OnCharacterExitDoorEnter = new UnityEvent();
        OnCharacterExitDoorExit = new UnityEvent();

        OnFinishedLevel = new UnityEvent();
    }
}
