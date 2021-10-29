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

    // with parameter settings, it's hard to get over 10000 points, which is logical. 
    private void Start()
    {
        currentTimerValue = timerMaxTime;
    }

    void Update()
    {
        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            GameObject go;
            // 50% combat, 50% food is ok
            if (UnityEngine.Random.Range(0, 2000) % 2 == 0)
            {
                var ind = GetRandomPrefabType(comboPrefabs.Length);
                // double check timer freeze combat to give it less possibility 
                // than other types of combats (here we have just 2 combats)
                if (ind == 0)
                {
                    ind = GetRandomPrefabType(comboPrefabs.Length);
                }
                go = Instantiate(comboPrefabs[ind]);
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

    private void UpdateTimerValueBasedOnScore()
    {
        // it looked more exciting
        if (playerController.playerScore % 1000 < 500 && playerController.playerScore % 500 >= 0)
        {
            timerMaxTime -= 0.02f;

            if (timerMaxTime < 0.4f)
                timerMaxTime = 0.4f;
        }
        else if (playerController.playerScore % 1000 > 500 && playerController.playerScore % 500 >= 0)
        {
            timerMaxTime -= 0.04f;

            if (timerMaxTime < 0.4f)
                timerMaxTime = 0.4f;
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
