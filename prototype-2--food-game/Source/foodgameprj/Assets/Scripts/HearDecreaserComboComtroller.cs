using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearDecreaserComboComtroller : ComboInstanceController
{

    // when player eats the combo item
    public override void OnConsume()
    {
        Debug.Log("HEART DECREASER ON CONSUME");
        eventSystem.OnDecreaseHeart.Invoke();

    }
}
