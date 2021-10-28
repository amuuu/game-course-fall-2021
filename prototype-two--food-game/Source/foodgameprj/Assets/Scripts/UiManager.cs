using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Text heartCountText;
    public GameObject LosePanel;
    public Text LoseScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHeartCountText(int heartCount)
    {
        heartCountText.text = heartCount.ToString();
        if(heartCount <= 0)
            Lose();
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
        LoseScore.text = scoreText.text;
        FindObjectOfType<PlayerController>().enabled = false;
        Time.timeScale = 0;
    }
}
