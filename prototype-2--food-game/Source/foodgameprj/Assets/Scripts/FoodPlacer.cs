using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacer : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] comboPrefabs;

    public float minX;
    public float maxX;

    public float timerMaxTime;
    private float currentTimerValue;

    public PlayerController playerController;
    private bool gameOver = false;
    public UITextController UiController;

    private void Start()
    {
        currentTimerValue = timerMaxTime;
    }

    void Update()
    {
        if (int.Parse(UiController.HeartCounterText.text) == 0)
        {
            gameOver = true;
            //Debug.Log("game over !!!!!!!");
            UiController.StatusText.text = "GAME OVER";
        }
        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            if (!gameOver)
            {
                GameObject go;

                if (UnityEngine.Random.Range(0, 2000) % 7 == 0)
                {
                    go = Instantiate(comboPrefabs[GetRandomPrefabType(comboPrefabs.Length)]);
                }
                else
                {
                    go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
                }

                go.transform.position = new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

                UpdateTimerValueBasedOnScore();

                // reset timer
                currentTimerValue = timerMaxTime;
            }
        }
    }

    private void UpdateTimerValueBasedOnScore()
    {
        if (playerController.playerScore % 400 < 200 && playerController.playerScore % 400 >= 0)
        {
            Debug.Log(timerMaxTime);
            timerMaxTime -= 0.02f;

            if (timerMaxTime < 0.5f)
                timerMaxTime = 0.5f;
        }

    }

    int GetRandomPrefabType(int max)
    {
        return UnityEngine.Random.Range(0, max);
    }

    float GetRandomPrefabInitialX()
    {
        return UnityEngine.Random.Range(minX,maxX);
    }
}
