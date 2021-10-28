using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreasComboControll : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume()
    {
        //var Hcount = FindObjectOfType<PlayerController>().playerHeartsCount;
        //if (Hcount > 0)
        //{
        //    Hcount--;
        //    FindObjectOfType<PlayerController>().playerHeartsCount = Hcount;
        //}

        FindObjectOfType<PlayerController>().HeartsCounts(-1);

        Debug.Log("Heart Decrease ON CONSUME");

        // you should fill this method!
    }
}
