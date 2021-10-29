using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int> {}

[System.Serializable]
public class MyStringEvent : UnityEvent<string> {}


public class EventSystemCustom : MonoBehaviour
{
    public static EventSystemCustom current; 
    public MyIntEvent onHealthChange;
    public MyIntEvent onScoreChange;
    public MyStringEvent onEndGame;
    void Awake()
    {
        current = this;
        onHealthChange = new MyIntEvent();
        onScoreChange = new MyIntEvent();
        onEndGame = new MyStringEvent();
    }
}