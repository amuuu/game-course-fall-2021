using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyText;
    public Text finishMsg;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.onCloneKeyCounterEnter.AddListener(UpdateKeyCounter);
        eventSystem.onCloneExitDoorEnter.AddListener(FinishGame);
        eventSystem.onCloneDeathZoneEnter.AddListener(GameOver);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
        counterText.text = newTextValue.ToString();
    }
    public void UpdateKeyCounter()
    {
        Debug.Log("UPDATE Keys");
        int newTextValue = int.Parse(keyText.text.Split(' ')[0]) + 1;
        keyText.text = newTextValue.ToString() + " Keys";
    }

    public void FinishGame()
    {
        Debug.Log("Game Finished");
        string newTextValue = "You Won!";
        finishMsg.text = newTextValue;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        string newTextValue = "You Lost!";
        finishMsg.text = newTextValue;
    }
}
