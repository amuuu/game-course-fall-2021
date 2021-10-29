using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHeartComboController : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume()
    {
        
        Debug.Log("Heart Decrease ON CONSUME");
        
    }
}
