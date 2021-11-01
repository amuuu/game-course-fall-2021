using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent UpdatScore;
    public UnityEvent UpdateHeart;
   

    void Awake()
    {
        
        UpdatScore = new UnityEvent();
        UpdateHeart = new UnityEvent();
       
    }
}
