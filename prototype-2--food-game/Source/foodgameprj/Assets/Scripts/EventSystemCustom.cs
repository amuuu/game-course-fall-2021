using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnIncreaseScore;
    public UnityEvent OnDecreaseScore;
    public UnityEvent OnGainHeart;
    public UnityEvent OnLoseHeart;

    void Awake()
    {
        OnIncreaseScore = new UnityEvent();
        OnDecreaseScore = new UnityEvent();
        OnGainHeart = new UnityEvent();
        OnLoseHeart = new UnityEvent();
    }
}
