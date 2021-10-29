using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;

    public int playerScore;
    public int playerHeartsCount;
    public GameObject canvas;
    //public GameObject foodPlacer;
    public FoodPlacer foodPlacer;
    private string _scoreString;
    private string _hearthString;

    private void Start()
    {
        playerScore = 0;
        playerHeartsCount = 5;
        // var canvasChildren = canvas.GetComponentsInChildren<Text>();
        // _scoreString = canvasChildren[0].text;
        // _hearthString = canvasChildren[1].text;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveAmount, 0, 0);
        }

        UpdateCanvasTexts();
    }

    private void UpdateCanvasTexts()
    {
        var canvasChildren = canvas.GetComponentsInChildren<Text>();
        _scoreString = "SCORE: " + playerScore.ToString();
        _hearthString = "Hearth: " + playerHeartsCount.ToString();
        canvasChildren[0].text = _scoreString;
        canvasChildren[1].text = _hearthString;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            // access the food object config
            FoodItemConfig conf = collision.gameObject.GetComponent<FoodInstanceController>().config;

            // increase the player's score
            playerScore += conf.score;

            Debug.Log("SCORE: " + playerScore);

            // destroy the food object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("HeartCombo"))
        {
            // polymorphism!
            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            HearthComboInstanceController comboController =  collision.gameObject.GetComponent<HearthComboInstanceController>();
            
            // the CONTENT of OnConsume method inside "TimeFreezerComboController" is available inside the "comboController"
            comboController.OnConsume(this);

            Debug.Log("COMBO!!! " + comboController.config.comboName);

            // destroy the combo object
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Combo"))
        {
            // polymorphism!
            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            TimeFreezerComboController comboController =  collision.gameObject.GetComponent<TimeFreezerComboController>();
            
            // the CONTENT of OnConsume method inside "TimeFreezerComboController" is available inside the "comboController"
            comboController.OnConsume(foodPlacer);

            Debug.Log("COMBO!!! " + comboController.config.comboName);

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }
}
