using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnPlayerKeyCollect;
    public UnityEvent OnPlayerWin;
    public UnityEvent OnPlayerLose;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnPlayerKeyCollect = new UnityEvent();
        OnPlayerWin = new UnityEvent();
        OnPlayerLose = new UnityEvent();
    }
}
