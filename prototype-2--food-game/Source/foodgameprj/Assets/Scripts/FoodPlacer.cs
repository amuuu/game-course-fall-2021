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


    private void Start()
    {
        currentTimerValue = timerMaxTime;
    }

    void Update()
    {
        if(playerController.playerHeartsCount > 0)
        {
            if (currentTimerValue > 0)
            {
                currentTimerValue -= Time.deltaTime;
            }
            else
            {
                GameObject go;

                if (UnityEngine.Random.Range(0, 2000) % 5 == 0)
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
        if (playerController.playerScore % 500 < 250 && playerController.playerScore % 500 >= 0)
        {
            timerMaxTime -= 0.05f;

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
