using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHeartComboController : HearthComboInstanceController
{
    public override void OnConsume(PlayerController player)
    {
        Debug.Log(player.playerHeartsCount);
        player.playerHeartsCount = player.playerHeartsCount + 1;
        Debug.Log(player.playerHeartsCount);
        Debug.Log("Increase Heart ON CONSUME");
    }
}
