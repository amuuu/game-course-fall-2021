using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public Text Score;
    public Text Heart;
    public Text gameOverTex;
    public Text WonText;
    public Button Restartbutton;
    public PlayerController playerController;
    public HeartComboController HeartComboController;
    public EventSystemCustom eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        Score.gameObject.SetActive(true);
        Heart.gameObject.SetActive(true);
        eventSystem.UpdatScore.AddListener(UpdateScore);
        eventSystem.UpdateHeart.AddListener(UpdateHeart);
        Restartbutton.gameObject.SetActive(false);
        WonText.gameObject.SetActive(false);
        gameOverTex.gameObject.SetActive(false);

        eventSystem.GameOver.AddListener(GameOverText);
        eventSystem.Win.AddListener(WinText);
    }

    // Update is called once per frame
    
       public  void UpdateScore()
        {
            Debug.Log("UPDATE KEYS");
            Score.text = "Score : " + playerController.playerScore.ToString();
        if(playerController.playerScore >= 3000)
        {
            eventSystem.Win.Invoke();
            Time.timeScale = 0;
        }

        }

    public void UpdateHeart()
    {
        Debug.Log("UPDATE Heart");
        Heart.text = "Heart : " + HeartComboController.heart.ToString();
        if(HeartComboController.heart == 0)
        {
            eventSystem.GameOver.Invoke();
            HeartComboController.heart = 3;
        }
        

    }
    public void WinText()
    {
        WonText.gameObject.SetActive(true);
    }

    public void GameOverText()
    {
        gameOverTex.gameObject.SetActive(true);
        Restartbutton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
