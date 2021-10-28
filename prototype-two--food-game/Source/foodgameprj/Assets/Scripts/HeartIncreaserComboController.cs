using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncreaserComboController : ComboInstanceController
{
    public override void OnConsume()
    {
        playerController.playerHeartsCount += 1;
    }
}
