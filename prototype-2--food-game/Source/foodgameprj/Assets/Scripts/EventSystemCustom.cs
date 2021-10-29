using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnScore;
    public UnityEvent OnHeart;
   
    void Awake()
    {
        OnScore = new UnityEvent();
        OnHeart = new UnityEvent();
    }
}
