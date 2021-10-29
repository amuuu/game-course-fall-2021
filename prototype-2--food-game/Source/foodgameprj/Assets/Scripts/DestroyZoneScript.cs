using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZoneScript : MonoBehaviour
{
    public UITextController UiController;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on trigger death zone ....");
        if (other.gameObject.CompareTag("Food"))
        {
            int newValue = int.Parse(UiController.HeartCounterText.text) - 1;
            UiController.HeartCounterText.text = newValue.ToString();
        }
    }
}
