using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinEventManager : MonoBehaviour
{
    public UnityEvent OnExitDoorWin;
    public UnityEvent OnDeathZoneLose;

    void Awake()
    {
        OnExitDoorWin = new UnityEvent();
        OnDeathZoneLose = new UnityEvent();
    }
}
