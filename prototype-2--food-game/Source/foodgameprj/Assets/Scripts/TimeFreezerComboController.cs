using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezerComboController : ComboInstanceController
{
    [Range(0.0f, 1.0f)] public float changeRate;
    bool actionDone = false;
    void Start()
    {
        AutoDestroyOnConsume = false;
    }
    void Update()
    {
        if (actionDone) DestroyCombo();
    }

    // when player eats the combo item
    protected override void OnConsumeAction(PlayerController playerController)
    {
        Debug.Log("TIME FREEZER ON CONSUME");
        
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;

        StartCoroutine(ChangeTimeScaleAndDestroy());
    }

    IEnumerator ChangeTimeScaleAndDestroy()
    {
        float newTimeScale = Time.timeScale;

        while(newTimeScale > 0f)
        {
            newTimeScale =  Time.timeScale - changeRate*Time.unscaledDeltaTime;
            if (newTimeScale < 0f) newTimeScale = 0f;
            Time.timeScale = newTimeScale;
            yield return null;
        }

        while(newTimeScale < 1f)
        {
            newTimeScale = Time.timeScale + changeRate*Time.unscaledDeltaTime;
            if (newTimeScale > 1f) newTimeScale = 1f;
            Time.timeScale = newTimeScale;
            yield return null;
        }
    }
    }
}
