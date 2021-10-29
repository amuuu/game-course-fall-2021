using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;

    public int playerScore;
    private int timeCombosCount;
    // public int playerHeartsCount;
    public EventSystemCustom eventSystem;

    private void Start()
    {
        timeCombosCount = 0;
        playerScore = 0;
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

            // emit update score signal
            eventSystem.onGetFood.Invoke();
            // Debug.Log("SCORE: " + playerScore);

            // destroy the food object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Combo"))
        {
            // polymorphism!
            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            ComboInstanceController comboController =  collision.gameObject.GetComponent<ComboInstanceController>();
            timeCombosCount += 1;
            // the CONTENT of OnConsume method inside "TimeFreezerComboController" is available inside the "comboController"
            comboController.OnConsume();
            // Debug.Log("COMBO!!! " + comboController.config.comboName);
            StartCoroutine("SpeedController");
            // destroy the combo object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("FishBone"))
        {

            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            ComboInstanceController comboController = collision.gameObject.GetComponent<ComboInstanceController>();


            comboController.OnConsume();
            eventSystem.onGetHeart.Invoke();

            // destroy the combo object
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("HeartIncreaser"))
        {

            // for example, the object of type "TimeFreezerComboController" which is the child of "ComboInstanceController", is put inside the "comboController" object below.
            ComboInstanceController comboController = collision.gameObject.GetComponent<ComboInstanceController>();


            comboController.OnConsume();
            eventSystem.onGetHeart.Invoke();

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }
    IEnumerator SpeedController()
    {
        if (timeCombosCount <= 1)
        {
            for (float ft = moveAmount; ft >= 0f; ft -= 0.002f)
            {
                moveAmount = ft;
                yield return new WaitForSeconds(.2f);
                if (moveAmount <= 0.0021f)
                {
                    moveAmount = 0;
                    break;
                }
            }
            for (float ft = moveAmount; ft <= 0.06f; ft += 0.002f)
            {
                if (moveAmount >= 0.575f)
                {
                    moveAmount = 0.6f;
                    break;
                }
                moveAmount = ft;
                yield return new WaitForSeconds(.2f);
            }
            timeCombosCount = 0;
        }
    }
}
