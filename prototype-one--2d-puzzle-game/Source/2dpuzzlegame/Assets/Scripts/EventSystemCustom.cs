using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent onCloneKeyCounterEnter;
    public UnityEvent onCloneExitDoorEnter;
    public UnityEvent onCloneDeathZoneEnter;
    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        onCloneKeyCounterEnter = new UnityEvent();
        onCloneExitDoorEnter = new UnityEvent();
        onCloneDeathZoneEnter = new UnityEvent();
    }
}
