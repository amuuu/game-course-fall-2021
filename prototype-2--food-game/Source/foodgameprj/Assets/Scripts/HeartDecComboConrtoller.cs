using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecComboConrtoller : ComboInstanceController
{
    public EventSystemCustom eventSystem = new EventSystemCustom();
    public override void OnConsume()
    {
        Debug.Log("HEART DECREASE COMBO");
        eventSystem.HeartCounterDecrese.Invoke();
    }
}
