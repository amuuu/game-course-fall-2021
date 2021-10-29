using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 10f)] public float moveAmount;

    public int playerScore;
    public int playerHeartsCount;
	//private float moveSpeed;
	public EventSystemCustom eventSystem;


	private void Start()
    {
        playerScore = 0;
		//moveSpeed = 1;
	}

	private void PlateSpeed()
	{
		if (playerScore % 100 > 80)
		{
			moveAmount += 0.01f;
			Debug.Log("speed " + moveAmount);
		}
	}

	void Update()
    {
		//as the score goes higher, move the plate faster as bonus
		PlateSpeed();

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveAmount * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveAmount * Time.deltaTime, 0, 0);
        }

		// if player looses all hearts --> end game
		if(playerHeartsCount == 0)
		{
			eventSystem.OnLooseCondition.Invoke();
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
			eventSystem.OnScoreIncrease.Invoke();

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

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }
}
