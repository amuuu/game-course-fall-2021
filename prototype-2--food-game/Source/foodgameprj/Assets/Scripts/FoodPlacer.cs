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

    public UIManager UiManager;

    public bool finishGame = false;

    private void Start()
    {
        currentTimerValue = timerMaxTime;
    }

    void Update()
    {
        if (finishGame)
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

            if (UnityEngine.Random.Range(0, 100) < 13)
            {
                go = Instantiate(comboPrefabs[GetRandomPrefabType(comboPrefabs.Length)]);
            }
            else
            {
                go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
                FoodItemConfig conf = go.GetComponent<FoodInstanceController>().config;
                Rigidbody rigid = go.GetComponent<Rigidbody>();
                Vector3 gravity = Vector3.down * conf.weight;
                rigid.AddForce(gravity, ForceMode.Acceleration);
            }

            go.transform.position = new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

            UpdateTimerValueBasedOnScore();

            // reset timer
            currentTimerValue = timerMaxTime;
        }
    }

    private void UpdateTimerValueBasedOnScore()
    { 
        if (
            UiManager.score % 10 == 0 && UiManager.score != 0 && UiManager.score > 0 ||
            UiManager.score % 5 == 0 && UiManager.score > 10 ||
            UiManager.score % 2 == 0 && UiManager.score > 20
            )
        {
            timerMaxTime -= 0.2f;

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
