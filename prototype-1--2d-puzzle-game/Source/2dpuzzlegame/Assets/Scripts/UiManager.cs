using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyText;
    public EventSystemCustom eventSystem;
    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnEatKeyEvent.AddListener(UpdateEatKeyText);
    }

    private void UpdateEatKeyText()
    {
        int newTextValue = int.Parse(keyText.text) + 1;
        keyText.text = newTextValue.ToString();
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }
}
