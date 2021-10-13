using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Text counterText;
    [SerializeField] Text endGameText;
    [SerializeField] Text savedKeysText;

    void Start()
    {
        // EventManager.current.onKeyCollect += UpdateSaveKeysText;
        EventSystemCustom.current.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        EventSystemCustom.current.onKeyCollect.AddListener(UpdateSaveKeysText);
        savedKeysText.text = "0 keys";
        endGameText.text = "";
    }
    
    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateSaveKeysText(int keys)
    {
        savedKeysText.text = keys+" keys";
    }

    public void EndGameTextWin()
    {
        endGameText.text = "You Win!";
    }
    public void EndGameTextLose()
    {
        endGameText.text = "You Lose!\nNOOB!";
    }
}
