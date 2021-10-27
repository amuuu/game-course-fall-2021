using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncComboConrtoller : ComboInstanceController
{
    public EventSystemCustom eventSystem;
    public override void OnConsume()
    {
        Debug.Log("HEART DECREASE COMBO");
        eventSystem.HeartCounterIncrease.Invoke();
    }
}
