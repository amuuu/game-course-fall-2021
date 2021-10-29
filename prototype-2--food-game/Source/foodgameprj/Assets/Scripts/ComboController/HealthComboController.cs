using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComboController : ComboInstanceController
{
    public PlayerController player;
    // when player eats the combo item
    public override void OnConsume()
    {
        Debug.Log("Health combo ON CONSUME");
        // HealthComboItemConfig healthComboItemConfig = (HealthComboItemConfig) config;
        // EventSystemCustom.current.onHealthChange.Invoke(playerHeartsCount);
        // player.playerHeartsCount += healthComboItemConfig.healthChange;
        // you should fill this method!
    }
}