using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 0.5f)] public float moveAmount;

    public int playerScore;
    public int playerHeartsCount;
    public bool movePlate;
    public Vector3 currentPosition;
    public int counter;

    private void Start()
    {
        playerScore = 0;
        playerHeartsCount = 0;
        counter = 0;
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
        if (FoodInstanceController.foodLoss == true)
        {

            counter += 1;
            FoodInstanceController.foodLoss = false;
            playerHeartsCount -= 1;
            heart.heartAmount -= 1;
        }
        if (playerHeartsCount < 0)
        {
            SceneManager.LoadScene("game over");

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
            score.scoreAmount += conf.score;

            Debug.Log("SCORE: " + score.scoreAmount);

            // destroy the food object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Combo"))
        {
            // polymorphism!
            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            ComboInstanceController comboController = collision.gameObject.GetComponent<ComboInstanceController>();

            // the CONTENT of OnConsume method inside "TimeFreezerComboController" is available inside the "comboController"

            playerHeartsCount -= comboController.config.heart;
            heart.heartAmount -= comboController.config.heart;

            Debug.Log("HEARTS: " + playerHeartsCount);

            Debug.Log("COMBO!!! " + comboController.config.comboName);

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }
}
