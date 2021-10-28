using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent GetHeartsCount;
    public UnityEvent GameOver;

    void Awake()
    {
        GetHeartsCount = new UnityEvent();
        GameOver = new UnityEvent();
    }
}
