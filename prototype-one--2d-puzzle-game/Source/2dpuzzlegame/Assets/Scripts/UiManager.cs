using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyScoreText;
    public EventSystemCustom eventSystem;
    
    void Start()
    {
        
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyEated.AddListener(UpdateKeyEatedScore);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
        counterText.text = newTextValue.ToString();
    }
    public void UpdateKeyEatedScore()
    {
        
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(keyScoreText.text) + 1;
        keyScoreText.text = newTextValue.ToString();
    }
}
