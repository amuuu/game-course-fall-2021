using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text keyCounter;
    public EventSystemCustom eventSystem;
    public PlayerMove playerMove;
    public Text gameOverTex;
    public Text WonText;
    public Button Restartbutton;

    void Start()
    {
        Restartbutton.gameObject.SetActive(false);
        WonText.gameObject.SetActive(false);
        gameOverTex.gameObject.SetActive(false);
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.UpdateKeys.AddListener(UpdateKeyCount);
        eventSystem.GameOver.AddListener(GameOverText);
        eventSystem.Win.AddListener(WinText);
    }
    public void WinText()
    {
        WonText.gameObject.SetActive(true);
    }

    public void GameOverText()
    {
        gameOverTex.gameObject.SetActive(true);
        Restartbutton.gameObject.SetActive(true);
    }
    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
        counterText.text = newTextValue.ToString();
    }
    public void UpdateKeyCount()
    {
        Debug.Log("UPDATE KEYS");
        keyCounter.text = "keys : " + playerMove.count.ToString();

    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}