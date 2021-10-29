using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHeartComboController : HearthComboInstanceController
{
    //public GameObject player;
    public override void OnConsume(PlayerController player)
    {
        Debug.Log(player.playerHeartsCount);
        player.playerHeartsCount = player.playerHeartsCount - 1;
        Debug.Log(player.playerHeartsCount);
        Debug.Log("Decrease Heart ON CONSUME");
    }
}
