using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsComboController : ComboInstanceController
{
    //Add hearts count by one
    public override void OnConsume()
    {
        PlayerController.playerHeartsCount++;
        Debug.LogWarning(PlayerController.playerHeartsCount);
    }
}
