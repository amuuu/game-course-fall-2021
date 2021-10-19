using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;
    public Text KeyCount;
    public GameObject  GOver;
    public GameObject Win;
    public Image teleportkeyPic;
    public Text switchpc;

    private void Awake() 
    {
        teleportkeyPic.enabled = false;
        GOver.SetActive(false);
        Win.SetActive(false);
        switchpc.enabled = false;
    }

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyGetStay.AddListener(UpdateKeyScoreText);
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }

    public void UpdateKeyScoreText()
    {
        Debug.Log("UPDATE KEY SCORE");
        string[] keys= KeyCount.text.Split(':');
        Debug.Log(keys);
        int newText = int.Parse(keys[1]) + 1;
        KeyCount.text = keys[0] + ": " + newText.ToString();
    }
    public void GameOverScene()
    {
        GOver.SetActive(true);
        FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
    }

    public void WiningScene()
    {
        Win.SetActive(true);
        FindObjectOfType<PlayerMove>().GetComponent<MonoBehaviour>().enabled = false;
    }

    public void GetteleportKey()
    {
        teleportkeyPic.enabled = true;
    }

}
