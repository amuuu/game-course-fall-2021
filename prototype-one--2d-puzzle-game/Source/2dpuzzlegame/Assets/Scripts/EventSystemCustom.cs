using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public class KeyEvent: UnityEvent<int> { }

    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnKeyPickup;
    public KeyEvent OnWinDoorInteract;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnKeyPickup = new UnityEvent();
        OnWinDoorInteract = new KeyEvent();
    }
}
