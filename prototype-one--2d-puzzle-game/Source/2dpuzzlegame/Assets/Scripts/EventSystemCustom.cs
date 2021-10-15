using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnCollectKey;
    public UnityEvent OnLoseKey;
    public UnityEvent OnLose;
    public UnityEvent OnWin;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnCollectKey = new UnityEvent();
        OnLose = new UnityEvent();
        OnWin = new UnityEvent();
    }
}
