using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBonesComboController : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume()
    {
        Debug.Log("FISH BONES ON CONSUME");
    }
}
