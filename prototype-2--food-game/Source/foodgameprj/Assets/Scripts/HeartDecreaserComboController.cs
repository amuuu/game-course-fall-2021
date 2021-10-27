using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaserComboController : ComboInstanceController
{
    public EventSystemCustom eventSystem;
   
    // when player eats the combo item
    public override void OnConsume()
    {
        eventSystem.OnHeartDecrease.Invoke();
    }
}
