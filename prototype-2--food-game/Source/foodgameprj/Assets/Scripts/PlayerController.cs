using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)] public float moveAmount;

    public int playerScore;
    public int playerHeartsCount;
    [SerializeField] private int heart;
    public EventSystemCustom eventSystem;
    public GameObject Heart3;
    public GameObject Heart2;
    public GameObject Heart1;


    private void Start()
    {
        playerScore = 0;
        heart = 3;
        eventSystem.OnHeartDecreaseCollected.AddListener(DeacreaseHeart);
        eventSystem.OnHeartIncreaseCollected.AddListener(IncreaseHeart);
    }

    private void updateHeartUI()
    {
        if (heart == 3)
        {
            Heart3.SetActive(true);
            Heart2.SetActive(true);
            Heart1.SetActive(true);
        }

        else if (heart == 2)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(true);
            Heart1.SetActive(true);
        }

        else if (heart == 1)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(true);
        }
        else if (heart == 0)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(false);
        }
    }

    private void DeacreaseHeart()
    {
        if (heart != 0)
        {
            heart--;
            updateHeartUI();
        }
    }

    private void IncreaseHeart()
    {
        if (heart != 3)
        {
            heart++;
            updateHeartUI();
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