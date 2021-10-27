using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text CollectedKeysText;
    public Text Win;
    public Text Lose;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.CollectKey.AddListener(UpdateCollectedKeys);
        eventSystem.Win.AddListener(UpdateWin);
        eventSystem.Lose.AddListener(UpdateLose);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateCollectedKeys()
    {
        Debug.Log("UPDATE COLLECTED KEYS");
        int newCollectedKeysValue = int.Parse(CollectedKeysText.text.Split(' ')[2]) + 1;
        CollectedKeysText.text = "Collected Keys: " + newCollectedKeysValue.ToString();
    }

    public void UpdateWin()
    {
        Debug.Log("YOU WON!");
        Win.text = "YOU WON!";
    }

    public void UpdateLose()
    {
        Lose.text = "YOU LOST!";
    }
}
