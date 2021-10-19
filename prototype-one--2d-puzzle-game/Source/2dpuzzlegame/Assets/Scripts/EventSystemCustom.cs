using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnKeyEated;
    public UnityEvent Door;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnKeyEated = new UnityEvent();
        Door = new UnityEvent();
    }
}
