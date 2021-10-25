using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezerComboController : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume(PlayerController player)
    {
        player.ateFreeze = true;
        player.ateFreezeStarting = true;
        Debug.Log("TIME FREEZER ON CONSUME");
        // you should fill this method!
    }
}