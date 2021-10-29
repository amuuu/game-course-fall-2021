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

    public float INIT_MAX_TIME;
    
    public float timerMaxTime;
    private float currentTimerValue;

    public PlayerController playerController;

    private int timeFreezer;

    private void Start()
    {
        timeFreezer = 0;
        timerMaxTime = INIT_MAX_TIME;
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

            if (UnityEngine.Random.Range(0, 2000) % 4 == 0)
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

    private void UpdateTimerValueBasedOnScore()
    {
        timerMaxTime = INIT_MAX_TIME - (playerController.playerScore / 100);

        if (timerMaxTime < 0.5f)
            timerMaxTime = 0.5f;
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
