using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBonesComboController : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume()
    {
        if (FindObjectOfType<UIManager>().playerHeartsCount > 0)
        {
            FindObjectOfType<UIManager>().playerHeartsCount -= 1;
        }
        // you should fill this method!
    }
}
