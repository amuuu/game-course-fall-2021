﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesComboController : ComboInstanceController
{
    public override void OnConsume()
    {
        PlayerController.playerHeartsCount--;
        Debug.LogWarning(PlayerController.playerHeartsCount);

    }
}
