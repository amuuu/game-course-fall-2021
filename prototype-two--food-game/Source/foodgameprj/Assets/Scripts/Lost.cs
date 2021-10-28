using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lost : MonoBehaviour
{
    GameObject obj;
    GameObject obj2;
    PlayerController player;
    FoodPlacer foodPlacer;
    public Text ScoreText;
    private void Start()
    {
        obj = GameObject.Find("Player");
        obj2 = GameObject.Find("FoodPlacer");
        player = obj.GetComponent<PlayerController>();
        foodPlacer=obj2.GetComponent<FoodPlacer>();
        ScoreText.text ="Score : "+ player.playerScore.ToString();
    }
    public void setup()
    {
        gameObject.SetActive(true);
        foodPlacer.enabled = false;
        Application.Quit();
    }
}
