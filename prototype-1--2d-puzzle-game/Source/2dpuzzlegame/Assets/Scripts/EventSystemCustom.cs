using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnKeyCollected;
    public UnityEvent OnTeleportKeyCollected;
    public UnityEvent PlayerShouldTeleport;
    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnKeyCollected = new UnityEvent();
        OnTeleportKeyCollected = new UnityEvent();
        PlayerShouldTeleport = new UnityEvent();
    }
}
