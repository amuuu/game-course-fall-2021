using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnEatKey;
    public UnityEvent OnWin;
    public UnityEvent OnDeathZone;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnEatKey = new UnityEvent();
        OnWin= new UnityEvent();
        OnDeathZone= new UnityEvent();

    }
}
