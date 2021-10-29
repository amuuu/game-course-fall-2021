using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthComboInstanceController : MonoBehaviour
{
    public ComboItemConfig config;

    // when player eats the combo item
    public virtual void OnConsume(PlayerController playerController)
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
