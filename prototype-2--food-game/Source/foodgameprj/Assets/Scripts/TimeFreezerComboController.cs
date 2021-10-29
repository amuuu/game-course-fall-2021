using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezerComboController : ComboInstanceController
{
    // when player eats the combo item
    private Vector3 graivty = new Vector3(0, -10.0F, 0);
    public FoodPlacer foodPlacer;
    void start()
    {
        Physics.gravity = graivty;
    }


    public override void OnConsume(GameObject gameObject)
    {
        StartCoroutine(FreezeTimeGradiantly(gameObject));
        Time.timeScale = 1;
        Debug.Log("TIME FREEZER ON CONSUME");

        // you should fill this method!
    }

    IEnumerator FreezeTimeGradiantly(GameObject gameObject)
    {
        foodPlacer.changeInstanciateState(false);
        gameObject.transform.position = new Vector3(1000, 1000, 1000);
        for (int i = 0; i < 10; i++)
        {
            if (Physics.gravity.y < 0.1f)
                Physics.gravity += new Vector3(0, 1F, 0);
            yield return new WaitForSecondsRealtime(0.1f);
        }

        for (int i = 0; i < 10; i++)
        {
            Physics.gravity -= new Vector3(0, 1F, 0);
            yield return new WaitForSecondsRealtime(0.1f);
        }
        foodPlacer.changeInstanciateState(true);
        Destroy(gameObject);
    }
}