using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncreaserComboController : ComboInstanceController
{
    protected override void OnConsumeAction(PlayerController playerController)
    {
        playerController.EarnHeart();
    }
}
