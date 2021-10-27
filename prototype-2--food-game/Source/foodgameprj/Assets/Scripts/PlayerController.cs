using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;

    public int playerScore;
    private int baseLevelUpValue, speedLevel;
    public int playerHeartsCount;
    public EventSystemCustom eventSystem;

    private void Start()
    {
        eventSystem.OnHeartDecreasePlayerScore.AddListener(DecreaseHeart);
        playerScore = 0;
        speedLevel = 1;
        baseLevelUpValue = 500;
    }

    void Update()
    {
        UpdateMovementSpeedValueBasedOnScore();

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveAmount, 0, 0);
        }
    }

    private void UpdateMovementSpeedValueBasedOnScore()
    {
        if (playerScore - baseLevelUpValue * speedLevel > 0 && speedLevel < 5)
        {
            moveAmount *= 1.3f;
            speedLevel++;
        }
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

            eventSystem.OnScoreUpdate.Invoke();

            // destroy the food object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Combo"))
        {
            // polymorphism!
            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            ComboInstanceController comboController =  collision.gameObject.GetComponent<ComboInstanceController>();

            // the CONTENT of OnConsume method inside "TimeFreezerComboController" is available inside the "comboController"
            comboController.OnConsume();

            Debug.Log("COMBO!!! " + comboController.config.comboName);

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }

    private void DecreaseHeart()
    {
        playerHeartsCount--;
        eventSystem.OnHeartDecreaseUIUpdate.Invoke();
    }
}
