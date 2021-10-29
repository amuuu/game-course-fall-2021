using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComboInstanceController : MonoBehaviour
{
    public ComboItemConfig config;
    protected bool AutoDestroyOnConsume { get; set; } = true;

    // when player eats the combo item
    public void OnConsume(PlayerController playerController)
    {
        OnConsumeAction(playerController);
        if (AutoDestroyOnConsume) DestroyCombo();
    }
    protected abstract void OnConsumeAction(PlayerController playerController);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
            DestroyCombo();
    }

    protected void DestroyCombo() => Destroy(this.gameObject);
}
