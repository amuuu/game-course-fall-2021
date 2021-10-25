using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FishBoneController : ComboInstanceController
{

    // when player eats the combo item
    public override void OnConsume(PlayerController player)
    {
        Debug.Log("You ate fish bone");
        player.playerHealth--;
    }
}