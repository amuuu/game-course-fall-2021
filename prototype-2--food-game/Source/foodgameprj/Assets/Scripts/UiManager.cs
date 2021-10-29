using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public Text heartText;
    public EventSystemCustom eventSystem;
 

    void Start()
    {
        eventSystem.OnScore.AddListener(UpdateScore);
        eventSystem.OnHeart.AddListener(UpdateHeartCount);
    }

    public void UpdateScore()
    {
        GameObject g = GameObject.Find("Player");
        int score = g.GetComponent<PlayerController>().playerScore;
        counterText.text = score.ToString();
    }

    public void UpdateHeartCount()
    {
        int val = int.Parse(heartText.text);
        if (val > 0)
            val--;
        heartText.text = val.ToString();
    }
}
