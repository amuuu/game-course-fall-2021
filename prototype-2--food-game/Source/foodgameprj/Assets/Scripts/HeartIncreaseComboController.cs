using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncreaseComboController : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume()
    {

        FindObjectOfType<PlayerController>().HeartsCounts(1);

        Debug.Log("Heart increase ON CONSUME");
    }
}
