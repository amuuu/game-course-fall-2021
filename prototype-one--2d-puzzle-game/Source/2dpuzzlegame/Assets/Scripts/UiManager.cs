using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Text counterText;
    [SerializeField] Text endGameText;
    [SerializeField] Text savedKeysText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        savedKeysText.text = "0/0";
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }
}
