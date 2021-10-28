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
        eventSystem.GetHeartsCount.AddListener(UpdateHeartCountText);
        eventSystem.GameOver.AddListener(GameOverScene);
    }


    public void ScoreCount(int amount)
    {
        string[] newText = counterText.text.Split(':');
        int hold = int.Parse(newText[1]) + amount;
        counterText.text = newText[0] + ": " + hold.ToString();
    }
    public void UpdateHeartCountText()
    {
        Debug.Log("UPDATE KEY SCORE");
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
    //    FindObjectOfType<PlayerController>().GetComponent<MonoBehaviour>().enabled = false;
          //FindObjectOfType<FoodPlacer>().GetComponent<MonoBehaviour>().enabled = false;
    //}
}
