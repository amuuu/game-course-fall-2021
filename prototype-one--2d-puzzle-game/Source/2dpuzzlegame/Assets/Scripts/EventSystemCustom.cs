using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent UpdateKeys;
    public UnityEvent GameOver;
    public UnityEvent Win;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        UpdateKeys = new UnityEvent();
        GameOver = new UnityEvent();
        Win = new UnityEvent();
    }
}
