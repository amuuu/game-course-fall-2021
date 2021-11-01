using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezerComboController : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume()
    {
        Debug.Log("TIME FREEZER ON CONSUME");

        Pause();
        // you should fill this method!
    }

     IEnumerator Pause()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(3);
        Time.timeScale = 1;
    }
}
