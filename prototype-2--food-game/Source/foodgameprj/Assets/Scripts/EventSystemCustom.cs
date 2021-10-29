using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent onFish;
    public UnityEvent onFishBone;
    void Awake()
    {
        onFish = new UnityEvent();
        onFishBone = new UnityEvent();
    }
}