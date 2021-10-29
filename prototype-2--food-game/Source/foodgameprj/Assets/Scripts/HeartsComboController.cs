using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsComboController : ComboInstanceController
{
    public override void OnConsume()
    {

        PlayerController.playerHeartsCount++;
        Debug.LogWarning(PlayerController.playerHeartsCount);

        // you should fill this method!
    }
}
