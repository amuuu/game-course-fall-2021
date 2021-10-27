using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent CollectKey;
    public UnityEvent Win;
    public UnityEvent Lose;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        CollectKey = new UnityEvent();
        Win = new UnityEvent();
        Lose = new UnityEvent();
    }
}
