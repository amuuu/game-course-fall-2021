using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text collectedKeysCounterText;
    public Text gameResultText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyPickup.AddListener(UpdateCollectedKeysCounterText);
        eventSystem.OnDoorOpened.AddListener(ShowWinText);
        eventSystem.OnDeathZoneEnter.AddListener(ShowLoseText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }
    public void UpdateCollectedKeysCounterText()
    {
        Debug.Log("UPDATE keys count");
        int newTextValue = int.Parse(collectedKeysCounterText.text) + 1;
        collectedKeysCounterText.text = newTextValue.ToString();
    }
    public void ShowWinText()
    {
        gameResultText.text = "YOU WON !";
        gameResultText.color = Color.green;
        gameResultText.gameObject.SetActive(true);
    }
    public void ShowLoseText()
    {
        gameResultText.text = "YOU LOST !";
        gameResultText.color = Color.red;
        gameResultText.gameObject.SetActive(true);
    }
}
