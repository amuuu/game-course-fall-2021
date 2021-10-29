using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezerComboController : MonoBehaviour
{
    public ComboItemConfig config;
    public void OnConsume(FoodPlacer foodPlacer)
    {
        foodPlacer.timerMaxTime = 2;
        // if (foodPlacer.playerController.playerScore > 100)
        // {
        //     foodPlacer.timerMaxTime = 2;            
        // }
        // else
        // {
        //     foodPlacer.timerMaxTime = foodPlacer.timerMaxTime + 0.5f;
        // }


        Debug.Log("timerMaxTime: " + foodPlacer.timerMaxTime.ToString());
        Debug.Log("TIME FREEZER ON CONSUME");

        // player.foodPlacer.GetComponent<ScriptableObject>()
        // foodPlacer
        // you should fill this method!
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            Destroy(this.gameObject);
        }
    }
}
