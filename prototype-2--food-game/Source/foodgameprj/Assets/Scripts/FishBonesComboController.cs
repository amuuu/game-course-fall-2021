using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBonesComboController : ComboInstanceController
{

    public override void OnConsume()
    {
        GameObject g = GameObject.Find("Player");
        int countNumber= g.GetComponent<PlayerController>().playerHeartsCount;
        countNumber--;
        Debug.Log("Hearts ON CONSUME" + countNumber);
    }

}
