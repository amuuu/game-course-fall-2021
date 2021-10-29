using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public static EventSystemCustom current;
    public UnityEvent onFish;
    public UnityEvent onFishBone;
    void Awake()
    {
        current = this;
        
        onFish = new UnityEvent();
        onFishBone = new UnityEvent();
    }
}