using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncreaserComboController : ComboInstanceController
{
    public override void OnConsume()
    {
        if (playerController.playerHeartsCount > 0)
        {
            playerController.playerHeartsCount += 1;
        }
    }
}
