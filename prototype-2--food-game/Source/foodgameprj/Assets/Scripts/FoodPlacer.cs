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
        if (playerController.playerScore % 400 < 200 /*&& playerController.playerScore % 400 >= 0*/)
        {
            timerMaxTime -= 0.03f;

            if (timerMaxTime < 0.5f)
                timerMaxTime = 0.5f;
        }

    }

    public void StartFreezingTime()
    {
        StartCoroutine(FreezingTime());
    }

    public IEnumerator FreezingTime()
    {
        for (int t = 19; t > 0; t-=1)
        {
            Time.timeScale -= 0.013f;
            yield return new WaitForSecondsRealtime(.013f);
        }
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(.013f);
        for (int t = 20; t > 0; t-=1)
        {
            Time.timeScale += 0.013f;
            yield return new WaitForSecondsRealtime(.013f);
        }
        Time.timeScale = 1;
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
