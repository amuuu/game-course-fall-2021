using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyCounter;
    public Text alertText;
    public Text alertDescription;
    public EventSystemCustom eventSystem;

    public PlayerMove playerMove;

    private int _stickyCounter = 0;

    void Start()
    {
        alertDescription.gameObject.SetActive(false);

        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyPickUp.AddListener(UpdateKeyText);
        eventSystem.WinningGame.AddListener(WinGame);
        eventSystem.LoosingGame.AddListener(LooseGame);
    }

    private void LooseGame()
    {
        alertText.color = Color.red;
        alertText.text = "You lost!";
        alertDescription.gameObject.SetActive(true);
    }

    private void WinGame()
    {
        alertText.color = Color.green;
        alertText.text = "You Won!";
        alertDescription.gameObject.SetActive(true);
    }

    private void UpdateKeyText()
    {
        Debug.Log("UPDATE SCORE");
        keyCounter.text = "Keys: " + playerMove.collectedKeys;
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        _stickyCounter++;
        counterText.text = "Sticky: " + _stickyCounter;
        keyCounter.text = "Keys: " + playerMove.collectedKeys;
    }
}