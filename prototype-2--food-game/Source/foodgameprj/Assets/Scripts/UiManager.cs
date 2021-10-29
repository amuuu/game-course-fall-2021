using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text playerHeartText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.onFish.AddListener(IncreasePlayerHeart);
        eventSystem.onFishBone.AddListener(DecreasePlayerHeart);
    }

    public void IncreasePlayerHeart()
    {
        Debug.Log("Increase Heart");
        int newTextValue = int.Parse(playerHeartText.text) + 1;
        playerHeartText.text = newTextValue.ToString();
    }
    public void DecreasePlayerHeart()
    {
        Debug.Log("Decrease Heart");
        int newTextValue = int.Parse(playerHeartText.text) - 1;
        playerHeartText.text = newTextValue.ToString();
    }
    
}