using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;
    public Text keyNumberText;
    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.KeyNum.AddListener(UpdateKeyNum);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateKeyNum()
    {
        Debug.Log("UPDATE KEY NUMBER");
        int newValue = int.Parse(keyNumberText.text) + 1;
        keyNumberText.text = newValue.ToString();
        Debug.Log(int.Parse(keyNumberText.text).ToString());
    }
}
