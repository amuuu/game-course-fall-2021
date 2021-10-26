using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;
    public Text Heart;          // Reference to key number text in UI
    public EventSystemCustom eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        Heart.text = FindObjectOfType<PlayerController>().playerHeartsCount.ToString();
        eventSystem.onGetFood.AddListener(UpdateScoreText);
        eventSystem.onGetHeart.AddListener(UpdateHeartText);
    }

    public void UpdateScoreText()
    {
        Score.text = FindObjectOfType<PlayerController>().playerScore.ToString();
        //Score.text = GetComponent<PlayerController>().playerScore.ToString();
        //Score.text;
        Debug.Log("UPDATE SCORE");
    }

    public void UpdateHeartText()
    {
        Heart.text = FindObjectOfType<PlayerController>().playerHeartsCount.ToString();
        Debug.Log("UPDATE Heart");
    }
}
