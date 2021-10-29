using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeFreezerComboController : ComboInstanceController
{
    [Range(0.0f, 1.0f)] public float changeRate;
    public Image frostFrame;
    bool actionDone = false;
    static TimeFreezerComboController activeCombo;

    void Start()
    {
        AutoDestroyOnConsume = false;
        frostFrame = GameObject.Find("FrostFrame").GetComponent<Image>();
    }
    void Update()
    {
        if (actionDone)
        {
            activeCombo = null;
            DestroyCombo();
        }
    }

    // when player eats the combo item
    protected override void OnConsumeAction(PlayerController playerController)
    {
        Debug.Log("TIME FREEZER ON CONSUME");
        if (activeCombo != null) activeCombo.DestroyCombo();
        activeCombo = this;

        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;

        StartCoroutine(ChangeTimeScaleAndDestroy());
        StartCoroutine(UpdateFrostFrame());
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

    IEnumerator UpdateFrostFrame()
    {
        while(!actionDone)
        {
            var color = frostFrame.color;
            color.a = (1 - Time.timeScale);
            Debug.LogWarning("scale&alpha: " + Time.timeScale + ", " + color.a);
            frostFrame.color = color;
            yield return null;
        }
    }
}
