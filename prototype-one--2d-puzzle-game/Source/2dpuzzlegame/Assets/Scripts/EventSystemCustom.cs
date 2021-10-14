using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnDoorOpened;
    public UnityEvent OnDeathZoneEnter;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnDoorOpened = new UnityEvent();
        OnDeathZoneEnter = new UnityEvent();
    }
}
