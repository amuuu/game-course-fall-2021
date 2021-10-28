using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyText;
    public Text specialKeyText;
    public Text result;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnCollectKey.AddListener(UpdateKeyScoreText);
        eventSystem.OnLoseKey.AddListener(DownGradeKeyScoreText);
        eventSystem.OnLose.AddListener(UpdateLoseText);
        eventSystem.OnWin.AddListener(UpdateWinText);
        eventSystem.OnCollectSpecialKey.AddListener(UpdateSpecialKeyScoreText);
        eventSystem.OnLoseSpecialKey.AddListener(DownGradeSpecialKeyScoreText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
        counterText.text = newTextValue.ToString();
    }

    public void UpdateKeyScoreText()
    {
        Debug.Log("UPDATE KEY");
        int newTextValue = int.Parse(keyText.text) + 1;
        keyText.text =  newTextValue.ToString();
    }

    public void DownGradeKeyScoreText()
    {
        Debug.Log("DOWNGRADE  KEY");
        int newTextValue = int.Parse(keyText.text) - 1;
        keyText.text = newTextValue.ToString();
    }

    public void UpdateLoseText()
    {
        Debug.Log("LOSE");
        string newTextValue = "YOU LOST!";
        result.text = newTextValue.ToString();
    }

    public void UpdateWinText()
    {
        Debug.Log("WIN");
        string newTextValue = "YOU WON!";
        result.text = newTextValue.ToString();
    }

    public void UpdateSpecialKeyScoreText()
    {
        Debug.Log("UPDATE SPECIAL  KEY");
        int newTextValue = int.Parse(specialKeyText.text) + 1;
        specialKeyText.text = newTextValue.ToString();
    }

    public void DownGradeSpecialKeyScoreText()
    {
        Debug.Log("DOWNGRADE SPECIAL  KEY");
        int newTextValue = int.Parse(specialKeyText.text) - 1;
        specialKeyText.text = newTextValue.ToString();
    }
}
