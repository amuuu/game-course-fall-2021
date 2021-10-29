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

    private int lastScore;

    private void Start()
    {
        currentTimerValue = timerMaxTime;
        lastScore = playerController.playerScore;
    }

    void Update()
    {
        if (!playerController)
        {
            Destroy(this.gameObject);
        }

        if (lastScore != playerController.playerScore)
        {
            lastScore = playerController.playerScore;
            UpdateTimerValueBasedOnScore();

        }

        if (currentTimerValue > 0)
        {
            currentTimerValue -= Time.deltaTime;
        }
        else
        {
            GameObject go;

            var rand = UnityEngine.Random.Range(0, 2000) % (prefabs.Length + 3 * comboPrefabs.Length);
            if (rand < 3 * comboPrefabs.Length)
            {
                go = Instantiate(comboPrefabs[GetRandomPrefabType(comboPrefabs.Length)]);
            }
            else
            {
                go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
            }

            go.transform.position = new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

            // reset timer
            currentTimerValue = timerMaxTime;
        }
    }

    private void UpdateTimerValueBasedOnScore()
    {
        if (playerController.playerScore % 400 < 200 && playerController.playerScore % 400 >= 0)
        {
            timerMaxTime -= 0.5f;

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
