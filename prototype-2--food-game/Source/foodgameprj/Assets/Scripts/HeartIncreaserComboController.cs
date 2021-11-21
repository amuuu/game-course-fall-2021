using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncreaserComboController : ComboInstanceController
{
    public override void OnConsume()
    {
        FindObjectOfType<PlayerController>().UpdateHeartsCount(1);
    }
}
