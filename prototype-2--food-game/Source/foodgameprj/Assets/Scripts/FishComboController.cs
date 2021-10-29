using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishComboController : ComboInstanceController
{
    // when player eats the fish bone
    public override void OnConsume()
    {
        Debug.Log("Heart Increase : " );
    }
}
