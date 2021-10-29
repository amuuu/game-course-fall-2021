using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 10f)] public float moveAmount;

    public int playerScore;
    public int playerHeartsCount;
    public UiManager uimanager;

    private void Start()
    {
        playerScore = 0;
        uimanager.UpdateScoreCount(playerScore);
        uimanager.UpdateHeartsCount(playerHeartsCount);
    }

    void Update()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
        float movementX = Input.GetAxis("Horizontal");
        transform.Translate(movementX * moveAmount * Time.deltaTime, 0, 0, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            // access the food object config
            FoodItemConfig conf = collision.gameObject.GetComponent<FoodInstanceController>().config;

            // increase the player's score
            AddScore(conf.score);

            Debug.Log("SCORE: " + playerScore);

            // destroy the food object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Combo"))
        {
            // polymorphism!
            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            ComboInstanceController comboController =  collision.gameObject.GetComponent<ComboInstanceController>();

            // the CONTENT of OnConsume method inside "TimeFreezerComboController" is available inside the "comboController"
            comboController.OnConsume(this);
            //combo destoys itself when done

            Debug.Log("COMBO!!! " + comboController.config.comboName);

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }

    public void LoseHeart()
    {
        playerHeartsCount--;
        uimanager.UpdateHeartsCount(playerHeartsCount);
        if(playerHeartsCount == 0)
            EndGame();
        Debug.Log("Heart lost");
    }
    public void EarnHeart()
    {
        playerHeartsCount++;
        uimanager.UpdateHeartsCount(playerHeartsCount);
        Debug.Log("Heart earned");
    }
    public void AddScore(int score)
    {
        playerScore += score;
        uimanager.UpdateScoreCount(playerScore);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        uimanager.ShowLoseText();
    }
}
