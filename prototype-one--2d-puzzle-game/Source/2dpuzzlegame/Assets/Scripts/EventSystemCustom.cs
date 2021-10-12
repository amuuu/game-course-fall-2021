using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    //public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnCharacterEatKey;
    public UnityEvent OnGameEndedWon;

    void Awake()
    {
        //OnCloneStickyPlatformEnter = new UnityEvent();
        OnCharacterEatKey = new UnityEvent();
        OnGameEndedWon = new UnityEvent();
    }
}
