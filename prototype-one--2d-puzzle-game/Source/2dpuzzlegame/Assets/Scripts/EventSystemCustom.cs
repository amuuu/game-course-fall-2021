using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnCollectedKeysEvent;
    public UnityEvent OnWinDoorEvent;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnCollectedKeysEvent = new UnityEvent();
        OnWinDoorEvent = new UnityEvent();
    }
}
