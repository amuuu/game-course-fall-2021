using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int> {}

public class EventSystemCustom : MonoBehaviour
{
    public static EventSystemCustom current;
    public UnityEvent OnCloneStickyPlatformEnter;
    public MyIntEvent onKeyCollect;

    void Awake()
    {
        current = this;
        OnCloneStickyPlatformEnter = new UnityEvent();
        onKeyCollect = new MyIntEvent();
    }
}
