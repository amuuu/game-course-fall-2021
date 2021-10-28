using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;

    [SerializeField] protected int playerScore;
    [SerializeField] protected int playerHeartsCount;

    public int getHeartCount()
    {
        return playerHeartsCount;
    }
    public int getScoreCount()
    {
        return playerScore;
    }
    public EventSystemCustom eventSystem;

    private void Start()
    {
        playerScore = 0;
        playerHeartsCount = 3;
        eventSystem.OnHeartDecreaseCollected.AddListener(DeacreaseHeart);
        eventSystem.OnHeartIncreaseCollected.AddListener(IncreaseHeart);
    }



    private void DeacreaseHeart()
    {
        if (playerHeartsCount != 0)
        {
            playerHeartsCount--;
            eventSystem.updateHeartUI.Invoke();
        }
    }

    private void IncreaseHeart()
    {
        if (playerHeartsCount != 3)
        {
            playerHeartsCount++;
            eventSystem.updateHeartUI.Invoke();
        }
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
            eventSystem.updateScoreUI.Invoke();
            // destroy the food object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Combo"))
        {
            // polymorphism!
            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            ComboInstanceController comboController = collision.gameObject.GetComponent<ComboInstanceController>();

            // the CONTENT of OnConsume method inside "TimeFreezerComboController" is available inside the "comboController"
            comboController.OnConsume();

            Debug.Log("COMBO!!! " + comboController.config.comboName);

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }
}