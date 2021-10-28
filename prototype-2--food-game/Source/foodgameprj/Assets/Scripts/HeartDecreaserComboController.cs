using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaserComboController : ComboInstanceController
{
    // when player eats the heart decreaser item
    public override void OnConsume()
    {
        Debug.Log("YOUR HEART DECREASED!");
        rigidBody = GetComponent<Rigidbody>();

    }
}