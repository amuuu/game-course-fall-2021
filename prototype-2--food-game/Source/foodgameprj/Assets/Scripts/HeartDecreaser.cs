using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaser : ComboInstanceController
{
    public EventSystemCustom eventSystem;
    // when player eats the combo item
    public override void OnConsume(GameObject gameObject)
    {
        Debug.Log("Heart Decreaser ON CONSUME");
        Destroy(gameObject);
        eventSystem.OnHeartDecreaseCollected.Invoke();

        // you should fill this method!
    }
}
