using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartComboController : ComboInstanceController
{
    public static int heart = 3;
    // when player eats the combo item
    public override void OnConsume()
    {
        Debug.Log("HEARTCOMBO ON CONSUME");
        heart--;
        Debug.Log(heart);
        // you should fill this method!
    }
}
