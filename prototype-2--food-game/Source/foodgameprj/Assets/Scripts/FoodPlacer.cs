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

    public double timerMaxTime;
    private double currentTimerValue;

    private int lastScore;

    public PlayerController playerController;
    public EventSystemCustom eventSystem;


    private void Start()
    {
        currentTimerValue = timerMaxTime;
        lastScore = 0;
    }

    void Update()
    {
        if (playerController.playerHeartsCount == 0)
        {
            return;
        }
        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            GameObject go;

            if (UnityEngine.Random.Range(0, 100) % 10 == 0)
            {
                go = Instantiate(comboPrefabs[GetRandomPrefabType(comboPrefabs.Length)]);
                go.GetComponent<ComboInstanceController>().playerController = playerController;
            }
            else
            {
                go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
                go.GetComponent<FoodInstanceController>().playerController = playerController;
                go.GetComponent<FoodInstanceController>().eventSystem = eventSystem;
            }

            go.transform.position = new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

            // reset timer
            currentTimerValue = timerMaxTime;
        }

        if (lastScore != playerController.playerScore)
        {
            lastScore = playerController.playerScore;
            UpdateTimerValueBasedOnScore();
        }
    }

    private void UpdateTimerValueBasedOnScore()
    {
        timerMaxTime -= GaussianFunction(playerController.playerScore);
    }

    private double GaussianFunction(int x, double a=0.25, double b=1000, double c =500000)
    {
        return a * Math.Exp(-1 * Math.Pow(x - b, 2) / c);
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
