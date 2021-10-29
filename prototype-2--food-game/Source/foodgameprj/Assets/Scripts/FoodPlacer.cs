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
        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            GameObject go;
            var rand = UnityEngine.Random.Range(0, 1000) % 25;

            if (rand >= 0 && rand <= 13) // 52% Food
                go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
            else if (rand <= 18) // 20% HeartDecreaser
                go = Instantiate(comboPrefabs[1]);
            else if (rand <= 22) // 16% TimeFreezer
                go = Instantiate(comboPrefabs[0]);
            else // 8% HeartIncreaser
                go = Instantiate(comboPrefabs[2]);

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
            playerController.increaseMovementSpeed(0.02f);
            Physics.gravity = new Vector3(0, Physics.gravity.y-0.25F, 0);

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
