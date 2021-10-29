using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoneComboController : ComboInstanceController
{
    // when player eats the fish bone
    public override void OnConsume()
    {
        Debug.Log("Heart decrease : ");
    }
}
