using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Text heartCountText;
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
    }
}
