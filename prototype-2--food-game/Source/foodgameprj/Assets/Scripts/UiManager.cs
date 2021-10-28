using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;
    public Text HeartCount;
    public GameObject  GOver;
    //public GameObject Win;

    private void Awake() 
    {
    }

    void Start()
    {
        eventSystem.GetFoodScoreCount.AddListener(UpdateScoreText);
        eventSystem.GetHeartsCount.AddListener(UpdateHeartCountText);
        eventSystem.GameOver.AddListener(GameOverScene);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        string[] newText = counterText.text.Split(':');
        int hold = int.Parse(newText[1]) + FindObjectOfType<PlayerController>().playerScore;
        counterText.text = newText[0] + ": " + hold.ToString();
    }

    public void UpdateHeartCountText()
    {
        Debug.Log("UPDATE KEY SCORE");
        //string[] keys= KeyCount.text.Split(':');
        //Debug.Log(keys);
        HeartCount.text = FindObjectOfType<PlayerController>().playerHeartsCount.ToString();
    }
    public void GameOverScene()
    {
        GOver.SetActive(true);
        FindObjectOfType<PlayerController>().GetComponent<MonoBehaviour>().enabled = false;
        FindObjectOfType<FoodPlacer>().GetComponent<MonoBehaviour>().enabled = false;
    }

    //public void WiningScene()
    //{
    //    Win.SetActive(true);
    //    //FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
    //}
}
