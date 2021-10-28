using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaserComboController : ComboInstanceController
{
    // when player eats the heart decreaser item
    public override void OnConsume()
    {
        //Debug.Log("YOUR HEART DECREASED!");
        int heart = GameObject.Find("Player").GetComponent<PlayerController>().playerHeartsCount;
        if(heart > 0)
            GameObject.Find("Player").GetComponent<PlayerController>().playerHeartsCount--;
        // else : loss
    }
}