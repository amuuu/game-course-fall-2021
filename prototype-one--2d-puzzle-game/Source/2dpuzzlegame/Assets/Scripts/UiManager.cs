using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
	public Text keyText;
	public Text win;
	public Text loose;
	public Text specialKeyText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyTrigger.AddListener(UpdateKeyText);
		eventSystem.OnWinCondition.AddListener(UpdateWinText);
		eventSystem.OnLooseCondition.AddListener(UpdateLooseText);
		eventSystem.OnSpecialKeyTrigger.AddListener(IncreaseSpecialKey);
		eventSystem.OnSpecialKeyDecrease.AddListener(DecreaseSpecialKey);
	}

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

	public void UpdateKeyText()
	{
		Debug.Log("UPDATE key counter");
		int newTextValue = int.Parse(keyText.text) + 1;
		keyText.text = newTextValue.ToString();
	}

	public void UpdateWinText()
	{
		//Debug.Log("Win!");
		win.text = "You Won!";
	}

	public void UpdateLooseText()
	{
		loose.text = "You Lost!";
	}

	public void IncreaseSpecialKey()
	{
		Debug.Log("specialKey increased");
		int newTextValue = int.Parse(specialKeyText.text) + 1;
		specialKeyText.text = newTextValue.ToString();
	}

	public void DecreaseSpecialKey()
	{
		Debug.Log("specialKey decreased");
		int newTextValue = int.Parse(specialKeyText.text) - 1;
		specialKeyText.text = newTextValue.ToString();
	}
}
