using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;

    public int playerScore;
    public int PlayerHearts;
    public PlayerRecords PlayerRecords;
    public FoodPlacer foodPlacer;
    public float GravityVolume;
    public bool timerFreeze;
    public float freezeTime;
    public float notSendFoodTime;
    public float increaseGravityVolume;

    private void Start()
    {
        
    }

    void Update()
    {
        if (timerFreeze)
        {
            GravityVolume += increaseGravityVolume;
            notSendFoodTime -= Time.deltaTime;
            if (notSendFoodTime>0)
            {
                foodPlacer.placeFoodOrNOt = false;

            }
            else
            {
                foodPlacer.placeFoodOrNOt = true;

            }

            if (GravityVolume >= 0)
            {
                freezeTime -= Time.deltaTime;
                GravityVolume = 0;

            }
            if(freezeTime < 0)
            {
                increaseGravityVolume=-0.5F;

            }
            if(GravityVolume <= -10)
            {
                GravityVolume = -10;
                increaseGravityVolume = 0.5F;
                foodPlacer.placeFoodOrNOt = true;
                timerFreeze = false;
            }
        }


        if (PlayerHearts == 0)
        {
            PlayerRecords.UpdateWonOrLostText("You lost and a loser doesn't deserve to play again so there is no restart");
            foodPlacer.placeFoodOrNOt = false;
        }
            
            
   
        Physics.gravity = new Vector3(0, GravityVolume, 0);
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveAmount, 0, 0);
        }
    }

    public void heartHandler(int getorlose)
    {
        PlayerHearts += getorlose;
        PlayerRecords.UpdateHeartsText(getorlose);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            // access the food object config
            FoodItemConfig conf = collision.gameObject.GetComponent<FoodInstanceController>().config;

            // increase the player's score
            playerScore += conf.score;
            PlayerRecords.UpdateScoreText(conf.score);

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
            comboController.OnConsume();

            Debug.Log("COMBO!!! " + comboController.config.comboName);
            if (comboController.config.comboName== "LoseHeart")
            {
                this.heartHandler(-1);
            }
            if (comboController.config.comboName == "GetHeart")
            {
                this.heartHandler(1);
            }
            if (comboController.config.comboName == "Time Freezer")
            {
                timerFreeze = true;
                freezeTime = 1;
                notSendFoodTime = 1.5F;
            }
            

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }
}
