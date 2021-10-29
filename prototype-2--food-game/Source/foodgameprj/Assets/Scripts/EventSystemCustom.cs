using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent onGetFood;
    public UnityEvent onGetHeart;

    void Awake()
    {
        onGetFood = new UnityEvent();
        onGetHeart = new UnityEvent();
    }
}
