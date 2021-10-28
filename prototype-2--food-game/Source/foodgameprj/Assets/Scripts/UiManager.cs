using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;
    public Text HeartCount;
    //public GameObject  GOver;
    //public GameObject Win;
    //public Image teleportkeyPic;

    private void Awake() 
    {
        //teleportkeyPic.enabled = false;
        //GOver.SetActive(false);
        //Win.SetActive(false);
    }

    void Start()
    {
        eventSystem.GetFoodScoreCount.AddListener(UpdateScoreText);
        eventSystem.GetHeartsCount.AddListener(UpdateHeartCountText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        string[] newText = counterText.text.Split(':');
        int hold = int.Parse(newText[1]) + FindObjectOfType<PlayerController>().playerScore;
        //int newTextValue = int.Parse(counterText.text) + FindObjectOfType<PlayerController>().playerScore;
        counterText.text = newText[0] + ": " + hold.ToString();
    }

    public void UpdateHeartCountText()
    {
        Debug.Log("UPDATE KEY SCORE");
        //string[] keys= KeyCount.text.Split(':');
        //Debug.Log(keys);
        HeartCount.text = FindObjectOfType<PlayerController>().playerHeartsCount.ToString();
    }
    //public void GameOverScene()
    //{
    //    GOver.SetActive(true);
    //    //FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
    //}

    //public void WiningScene()
    //{
    //    Win.SetActive(true);
    //    //FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
    //}

    //public void GetteleportKey()
    //{
    //    teleportkeyPic.enabled = true;
    //}

    //public void SwitchPlayerAndClone()
    //{
    //    return;
    //}
}
