using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCombo : ComboInstanceController
{
    // when player eats the combo item
    public override void OnConsume(GameObject gameObject)
    {
        Debug.Log("Heart Decreaser ON CONSUME");
        Destroy(gameObject);
        PlayerController.decreaseHeart();
        // eventSystem.OnHeartDecreaseCollected.Invoke();

        // you should fill this method!
    }
}