using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 0.9f)] public float moveAmount;

    public int playerScore;
    public static int playerHeartsCount;

    [SerializeField] UnityEngine.UI.Text scoreText;
    [SerializeField] UnityEngine.UI.Text heartText;
    [SerializeField] UnityEngine.UI.Text timeFreezeTxt;

    [SerializeField] AudioSource collectFruitSFX;

    private void Start()
    {
        playerScore = 0;
        playerHeartsCount = 3;
    }

    private void Update()
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
            collectFruitSFX.Play();
            // access the food object config
            FoodItemConfig conf = collision.gameObject.GetComponent<FoodInstanceController>().config;

            // increase the player's score
            playerScore += conf.score;

            //update the score on screen
            scoreText.text = "Score: " +  playerScore.ToString();

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

            //Time freezing process
            StartPause();
            timeFreezeTxt.color = Color.magenta;
            timeFreezeTxt.text = "Time is Freezed!";


            // destroy the combo object
            Destroy(collision.gameObject);
        }

        //Decreasing hearts
        if (collision.gameObject.CompareTag("Bones"))
        {
            ComboInstanceController comboController = collision.gameObject.GetComponent<ComboInstanceController>();

            // the CONTENT of OnConsume method inside "BonesComboController" is available inside the "comboController"
            comboController.OnConsume();

            //update heart UI
            heartText.text = "Lifes ♥ : " + playerHeartsCount.ToString();

            // destroy the combo object
            Destroy(collision.gameObject);
        }

        //Taking extra heart
        if (collision.gameObject.CompareTag("Heart"))
        {
            collectFruitSFX.Play();
            ComboInstanceController comboController = collision.gameObject.GetComponent<ComboInstanceController>();

            // the CONTENT of OnConsume method inside "HeartsComboController" is available inside the "comboController"
            comboController.OnConsume();

            //update heart UI
            heartText.text = "Lifes ♥ : " + playerHeartsCount.ToString();

            // destroy the combo object
            Destroy(collision.gameObject);
        }
    }

    public void StartPause()
    {
        StartCoroutine(PauseGame(3f));
    }

    public IEnumerator PauseGame(float pauseTime)
    {
        Debug.Log("Start Freezing!");


        yield return new WaitForSeconds(0.5f);
        timeFreezeTxt.color = Color.yellow;
        timeFreezeTxt.text = "Take a Breath...";

        yield return new WaitForSeconds(0.5f);
        timeFreezeTxt.color = Color.cyan;
        timeFreezeTxt.text = "Ready?";

        

        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            //timeFreezeTxt.color = Color.magenta;
            //timeFreezeTxt.text = "Time is Freezed!";
            yield return 0;
        }
        Time.timeScale = 1f;

        yield return new WaitForSeconds(0.4f);
        timeFreezeTxt.color = Color.green;
        timeFreezeTxt.text = "Go!";

        yield return new WaitForSeconds(0.3f);
        timeFreezeTxt.text = "";

        Debug.Log("Freezing Finished!");
    }
}
