using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComboInstanceController : MonoBehaviour
{
    public ComboItemConfig config;

    // when player eats the combo item
    public abstract void OnConsume(PlayerController playerController);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            Destroy(this.gameObject);
        }
    }
}
