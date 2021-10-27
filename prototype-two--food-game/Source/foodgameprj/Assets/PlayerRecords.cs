using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRecords : MonoBehaviour
{
    public Text Score;
    public Text Hearts;
    public int PlayerHearts;

    void Start()
    {
        Score.text = "0";
        Hearts.text = "3 X";
    }

    public void UpdateScoreText(int AddedScore)
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(Score.text) + AddedScore;
        Score.text = newTextValue.ToString();
    }

    public void UpdateHeartsText(int AddedHeart)
    {
        Debug.Log("UPDATE HEART");
        string[] tokens = (Hearts.text.Split(' '));
        int newTextValue = int.Parse(tokens[0]) + AddedHeart;
        Hearts.text = newTextValue.ToString() + " X";
    }

    public void UpdateWonOrLostText(string won)
    {
    
    }
}
