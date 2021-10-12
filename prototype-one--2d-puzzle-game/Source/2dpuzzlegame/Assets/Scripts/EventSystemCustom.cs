using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public MyIntEvent onCollectKey;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        onCollectKey = new MyIntEvent();
    }
}

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}
