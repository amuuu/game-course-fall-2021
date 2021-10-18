using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnEatKey;
    public UnityEvent OnWin;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnEatKey = new UnityEvent();
        OnWin= new UnityEvent();

    }
}
