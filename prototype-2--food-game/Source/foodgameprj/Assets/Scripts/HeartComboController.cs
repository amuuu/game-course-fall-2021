using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartComboController : ComboInstanceController
{
    public int heart = 3;
    public EventSystemCustom eventSystem;
    // when player eats the combo item
    public override void OnConsume()
    {
        Debug.Log("HEARTCOMBO ON CONSUME");
        heart--;
        Debug.Log(heart);
        eventSystem.UpdateHeart.Invoke();
        // you should fill this method!
    }
}
