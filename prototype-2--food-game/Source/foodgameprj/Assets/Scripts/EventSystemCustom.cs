using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnScore;
    public UnityEvent OnIncreaseHeart;
    public UnityEvent OnDecreaseHeart;
    public UnityEvent YouLost;


    void Awake()
    {
        OnScore = new UnityEvent();
        OnIncreaseHeart = new UnityEvent();
        OnDecreaseHeart = new UnityEvent();
        YouLost = new UnityEvent();
    }
}
