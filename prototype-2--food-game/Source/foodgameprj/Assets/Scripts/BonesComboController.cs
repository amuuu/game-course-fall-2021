using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesComboController : ComboInstanceController
{
    //decrease heart by one
    public override void OnConsume()
    {
        PlayerController.playerHeartsCount--;
        Debug.LogWarning(PlayerController.playerHeartsCount);
    }
}
