using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaseOnFishBone : ComboInstanceController
{
    // when player eats the fish bone
    private int heartCounter = 0;
    public override void OnConsume()
    {
        heartCounter--;
        Debug.Log("Heart decrease : ", heartCounter);
    }
}
