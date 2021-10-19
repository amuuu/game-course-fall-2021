using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public static class Global
//{

//    public static Text counterKey;
//}

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;

    private Text counterKey ;
    

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        counterKey.text = "Key: " + 0;
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
        counterText.text = newTextValue.ToString();
    }

    public void UpdateKeyText(int keyCounter)
    {
        Debug.Log("UPDATE KEY");
        counterKey.text = "Key: " + keyCounter.ToString();
    }
}
