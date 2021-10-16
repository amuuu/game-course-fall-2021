using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityIntEvent OnKeyPickup; // invoke with number of collected keys
    public UnityIntEvent OnPortalKeyPickup; // invoke with number of collected keys
    public UnityEvent OnDoorOpened;
    public UnityEvent OnDeathZoneEnter;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnKeyPickup = new UnityIntEvent();
        OnPortalKeyPickup = new UnityIntEvent();
        OnDoorOpened = new UnityEvent();
        OnDeathZoneEnter = new UnityEvent();
    }
}

public class UnityIntEvent : UnityEvent<int> {}
