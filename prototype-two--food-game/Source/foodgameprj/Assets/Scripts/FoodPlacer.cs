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

    private float freezeTimer = 0;
    public float freezeTimerMaxTime;


    private void Start()
    {
        currentTimerValue = timerMaxTime;
        freezeTimer = 0;
    }

    void Update()
    {
        if (freezeTimer > 0)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                UnFreezeTimer();
            }
            return;
        }
            
        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            GameObject go;

            if (UnityEngine.Random.Range(0, 2000) % 2 == 0)
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
        if (playerController.playerScore % 400 < 200 && playerController.playerScore % 400 >= 0)
        {
            timerMaxTime -= 0.02f;

            if (timerMaxTime < 0.5f)
                timerMaxTime = 0.5f;
        }

    }

    public void FreezeTimer()
    {
        freezeTimer = freezeTimerMaxTime;
        foreach( FoodInstanceController food in FindObjectsOfType<FoodInstanceController>())
        {
            food.rigidBody.useGravity = false;
        }
    }

    private void UnFreezeTimer()
    {
        foreach (FoodInstanceController food in FindObjectsOfType<FoodInstanceController>())
        {
            food.rigidBody.useGravity = true;
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
