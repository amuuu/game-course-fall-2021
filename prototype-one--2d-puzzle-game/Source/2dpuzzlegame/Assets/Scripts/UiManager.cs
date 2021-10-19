using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyCounter;
    public EventSystemCustom eventSystem;

    public PlayerMove playerMove;

    private int stickyCounter = 0;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyPickUp.AddListener(UpdateKeyText);
    }

    private void UpdateKeyText()
    {
        Debug.Log("UPDATE SCORE");
        keyCounter.text = "Keys: " + playerMove.collectedKeys;
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        stickyCounter++;
        counterText.text = "Sticky: " + stickyCounter;
        keyCounter.text = "Keys: " + playerMove.collectedKeys;
    }
}