using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboInstanceController : MonoBehaviour
{
    public ComboItemConfig config;
    public Rigidbody rigidBody;
    public UIManager Ui;

    // when player eats the combo item
    public virtual void OnConsume()
    {
        Debug.Log("PARENT CLASS ON CONSUME");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            Destroy(this.gameObject);
        }
    }
}
