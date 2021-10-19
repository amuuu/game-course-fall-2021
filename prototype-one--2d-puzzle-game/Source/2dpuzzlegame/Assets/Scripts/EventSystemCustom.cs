using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnKeyTrigger;
	public UnityEvent OnWinCondition;
	public UnityEvent OnLooseCondition;
	public UnityEvent OnSpecialKeyTrigger;
	public UnityEvent OnSpecialKeyDecrease;

	void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
		OnKeyTrigger = new UnityEvent();
		OnWinCondition = new UnityEvent();
		OnLooseCondition = new UnityEvent();
		OnSpecialKeyTrigger = new UnityEvent();
		OnSpecialKeyDecrease = new UnityEvent();
	}
}
