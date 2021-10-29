using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaserComboController : ComboInstanceController
{
    protected override void OnConsumeAction(PlayerController playerController)
    {
        playerController.LoseHeart();
    }
}
