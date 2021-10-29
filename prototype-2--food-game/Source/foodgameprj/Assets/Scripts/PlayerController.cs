using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;

    public int playerScore;
    public int playerHeartsCount;
    private int freezeState;
    public float TIME_SCALE_CHANGE;
    private void Start()
    {
        playerScore = 0;
        freezeState = 0;
        EventSystemCustom.current.onFreeze.AddListener(UpdateFreezeState);
        EventSystemCustom.current.onHealthChange.Invoke(playerHeartsCount);
        EventSystemCustom.current.onScoreChange.Invoke(0);
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

        switch (freezeState)
        {
            case 1:
                Debug.Log("TIME SCALE "+Time.timeScale);
                if (Time.timeScale - TIME_SCALE_CHANGE <0)
                {
                    Time.timeScale = 0;
                    freezeState = 2;
                }
                else
                {
                    Time.timeScale -= TIME_SCALE_CHANGE;
                }
                break;
            case 2:
                ;
                if (Time.timeScale + TIME_SCALE_CHANGE >1)
                {
                    Time.timeScale = 1;
                    freezeState = 0;
                }
                else
                {
                    Time.timeScale += TIME_SCALE_CHANGE;
                }
                break;
        }
    }

    private void UpdateFreezeState()
    {
        freezeState = 1;
        Time.timeScale = 1;
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
            EventSystemCustom.current.onScoreChange.Invoke(playerScore);

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
            

            Debug.Log("COMBO!!! " + comboController.config.comboName+" health:"+playerHeartsCount);
            
            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }
}
