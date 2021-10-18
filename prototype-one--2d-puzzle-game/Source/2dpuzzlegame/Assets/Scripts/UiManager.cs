using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;
    public Text storedKey ;
    public Text WonText;



    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnEatKey.AddListener(UpdateStoredkey);
        eventSystem.OnWin.AddListener(Win);

    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateStoredkey()
    {
        Debug.Log("UPDATE key");
        int valKey = int.Parse(storedKey.text) + 1;
        storedKey.text = valKey.ToString();
    }
     public void Win()
    {
        WonText.text = "You Won!";
    }
}
