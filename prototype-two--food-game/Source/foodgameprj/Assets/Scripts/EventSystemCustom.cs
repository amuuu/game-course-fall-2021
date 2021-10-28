using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnHeartDecreaserEnter;
    public UnityEvent OnFoodToPlateEnter;

    void Awake()
    {
        OnHeartDecreaserEnter = new UnityEvent();
        OnFoodToPlateEnter = new UnityEvent();
    }
}
