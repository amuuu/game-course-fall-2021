using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustomScript : MonoBehaviour
{
    public UnityEvent OnEatFood;
    //public UnityEvent OnGameEndedWon;
    //public UnityEvent OnGameEndedLost;
    public UnityEvent OnUpdateRemainingTime;
    public UnityEvent OnDecreaseHeart;

    void Awake()
    {
        //OnCloneStickyPlatformEnter = new UnityEvent();
        OnEatFood = new UnityEvent();
        OnUpdateRemainingTime = new UnityEvent();
        OnDecreaseHeart = new UnityEvent();
    }
}
