using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesComboController : ComboInstanceController
{
    public override void OnConsume()
    {
        
        int heartCnt =  PlayerController.playerHeartsCount;
        heartCnt--;
        Debug.LogWarning(heartCnt);

        // you should fill this method!
    }
}
