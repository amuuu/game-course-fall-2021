using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncreaserComboController : ComboInstanceController
{

    // when player eats the combo item
    public override void OnConsume()
    {
        Debug.Log("HEART INCREASER ON CONSUME");
        eventSystem.OnIncreaseHeart.Invoke();

    }
}
