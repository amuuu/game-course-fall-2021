using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaser : ComboInstanceController
{
    public EventSystemCustom eventSystem;
    // when player eats the combo item
    private void Start()
    {
    }

    public override void OnConsume()
    {
        Debug.Log("Heart Decreaser ON CONSUME");
        eventSystem.OnHeartDecreaseCollected.Invoke();

        // you should fill this method!
    }
}
