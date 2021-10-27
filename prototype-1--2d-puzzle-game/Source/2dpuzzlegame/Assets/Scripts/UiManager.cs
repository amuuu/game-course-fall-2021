using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyCollectedText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyCollected.AddListener(UpdatekeyCollectedText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }
    public void UpdatekeyCollectedText()
    {
        Debug.Log("UPDATE KeyCollected Score");
        var text = keyCollectedText.text;
        text = text.Split(':')[1];
        var number = int.Parse(text);
        int newTextValue = number + 1;
        keyCollectedText.text = "Keys:"+newTextValue.ToString();
    }
}
