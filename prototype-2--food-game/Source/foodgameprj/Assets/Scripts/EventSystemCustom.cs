using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent UpdatScore;
    public UnityEvent UpdateHeart;
    public UnityEvent Win;
    public UnityEvent GameOver;


    void Awake()
    {
        
        UpdatScore = new UnityEvent();
        UpdateHeart = new UnityEvent();
        Win = new UnityEvent();
        GameOver = new UnityEvent();
    }
}
