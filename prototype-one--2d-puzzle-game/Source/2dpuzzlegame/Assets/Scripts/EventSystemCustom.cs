using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter, 
        OnAccquiredKey, OneCharacterNearObjectEnter, OneCharacterNearObjectExit;  //key logic

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnAccquiredKey = new UnityEvent();
        OneCharacterNearObjectEnter = new UnityEvent();
        OneCharacterNearObjectExit = new UnityEvent();
    }
}
