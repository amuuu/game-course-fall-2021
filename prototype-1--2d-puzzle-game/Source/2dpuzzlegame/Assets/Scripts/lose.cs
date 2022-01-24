using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour
{
    public GameObject losePage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("User"))
        {
            losePage.SetActive(true);
        }
    }

}
