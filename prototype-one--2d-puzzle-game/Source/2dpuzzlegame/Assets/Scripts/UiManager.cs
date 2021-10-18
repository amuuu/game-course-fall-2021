using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyCollectedText;
	public Text winOrLooseText;

    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
		eventSystem.OnKeyCollected.AddListener(UpdateKeyCollectedText);
		eventSystem.OnPlayerWin.AddListener(UpdateWinText);
		eventSystem.OnPlayerLoose.AddListener(UpdateLooseText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

	public void UpdateKeyCollectedText()
    {
        Debug.Log("UPDATE Key");
        int newTextValue = int.Parse(keyCollectedText.text) + 1;
            keyCollectedText.text = newTextValue.ToString();
    }

	public void UpdateWinText()
    {
        Debug.Log("UPDATE Win");
		winOrLooseText.text = "You Won!";
    }
	public void UpdateLooseText()
    {
        Debug.Log("UPDATE Loose");
		winOrLooseText.text = "You Lost!";
    }
}
