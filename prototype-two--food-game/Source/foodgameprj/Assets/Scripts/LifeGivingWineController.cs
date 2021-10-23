using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGivingWineController : ComboInstanceController
{
    public override void OnConsume(PlayerController player)
    {
        Debug.Log("You ate life giving wine!");
        player.playerHealth++;
    }
}