using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaserComboController : ComboInstanceController
{
    public override void OnConsume(PlayerController playerController)
    {
        playerController.LoseHeart();
    }
}
