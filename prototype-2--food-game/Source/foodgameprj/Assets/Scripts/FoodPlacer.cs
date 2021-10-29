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
    private bool gameStatus;
    public PlayerController playerController;


    private void Start()
    {
        gameStatus = true;
        currentTimerValue = timerMaxTime;
    }

    public void changeInstanciateState(bool status)
    {
        gameStatus = status;
    }

    void Update()
    {
        if (gameStatus)
        {
            if (currentTimerValue > 0)
            {
                currentTimerValue -= Time.deltaTime;
            }
            else
            {
                GameObject go;

                if (UnityEngine.Random.Range(0, 2000) % 3 == 0)
                {
                    go = Instantiate(comboPrefabs[GetRandomPrefabType(comboPrefabs.Length)]);
                }
                else
                {
                    go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
                }

                go.transform.position =
                    new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

                UpdateTimerValueBasedOnScore();

                // reset timer
                currentTimerValue = timerMaxTime;
            }
        }
        else
        {
            Debug.Log("Injaaas");
        }
    }

    private void UpdateTimerValueBasedOnScore()
    {
        if (playerController.getScoreCount() % 400 < 200 && playerController.getScoreCount() % 400 >= 0)
        {
            timerMaxTime -= 0.02f;

            if (timerMaxTime < 0.35f)
                timerMaxTime = 0.35f;
        }
    }

    int GetRandomPrefabType(int max)
    {
        return UnityEngine.Random.Range(0, max);
    }

    float GetRandomPrefabInitialX()
    {
        return UnityEngine.Random.Range(minX, maxX);
    }
}