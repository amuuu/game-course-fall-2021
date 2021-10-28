using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Heart3;
    public GameObject Heart2;
    public GameObject Heart1;
    public Text ScoreText;

    // Start is called before the first frame update
    public EventSystemCustom eventSystem;
    void Start()
    {
        eventSystem.updateHeartUI.AddListener(updateHeartUI);
        eventSystem.updateScoreUI.AddListener(updateScoreUI);
    }

    private void updateScoreUI()
    {
        int playerScoreCount=GameObject.Find("Player").GetComponent<PlayerController>().getScoreCount();
        ScoreText.text = playerScoreCount.ToString();
    }
    private void updateHeartUI()
    {
        int playerHeartsCount=GameObject.Find("Player").GetComponent<PlayerController>().getHeartCount();
        if (playerHeartsCount == 3)
        {
            Heart3.SetActive(true);
            Heart2.SetActive(true);
            Heart1.SetActive(true);
        }

        else if (playerHeartsCount == 2)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(true);
            Heart1.SetActive(true);
        }

        else if (playerHeartsCount == 1)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(true);
        }
        else if (playerHeartsCount == 0)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(false);
        }
    }
    // Update is called once per frame

}
