using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnGetKey.AddListener(UpdateScoreText);
    }

    public void UpdateScoreText()
    {
        int newTextValue = int.Parse(counterText.text) + 1;
        counterText.text = newTextValue.ToString();
    }
}
