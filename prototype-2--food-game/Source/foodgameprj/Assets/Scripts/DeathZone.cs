using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            eventSystem.OnDecreaseHeart.Invoke();
        }
    }
}
