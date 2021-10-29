using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent updateScore;
    public UnityEvent updateHeartCount;
    public int playrScore;

    void Awake()
    {
        updateScore = new UnityEvent();
        updateHeartCount = new UnityEvent();
    }
}
