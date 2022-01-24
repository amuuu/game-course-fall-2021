using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishCombo : ComboInstanceController
{
    // when player eats the combo ite

    public override void OnConsume(GameObject gameObject)
    {
        Debug.Log("Heart Decreaser ON CONSUME");

        Destroy(gameObject);

        // eventSystem.OnHeartDecreaseCollected.Invoke();

        // you should fill this method!
    }
}