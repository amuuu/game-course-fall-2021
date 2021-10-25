using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacer : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public GameObject[] prefabs;
    public GameObject[] comboPrefabs;

    public float minX;
    public float maxX;

    public double timerMaxTime = 2;
    private double currentTimerValue;

    public PlayerController playerController;

    public bool isRaining;

    private void Start()
    {
        currentTimerValue = timerMaxTime;
        isRaining = true;
        eventSystem.onGameOver.AddListener((() => isRaining = false));
    }

    void Update()
    {
        if (isRaining)
        {
            if (currentTimerValue > 0)
            {
                currentTimerValue -= Time.deltaTime;
            }
            else
            {
                GameObject go;

                if (UnityEngine.Random.Range(0, 15000) % 15 > 11)
                {
                    var comboP = UnityEngine.Random.Range(0, 100) % 50;
                    if (comboP % 50 > 47)
                    {
                        go = Instantiate(comboPrefabs[0]);
                    }
                    else if (comboP > 45 && playerController.playerHealth < 3)
                    {
                        go = Instantiate(comboPrefabs[2]);
                    }
                    else
                    {
                        go = Instantiate(comboPrefabs[1]);
                    }
                }
                else
                {
                    go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
                }

                go.transform.position =
                    new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

                UpdateTimerValueBasedOnScore();
                var rigidBody = go.GetComponent<Rigidbody>();
                Vector3 force = new Vector3(0.0f, -1.0f, 0.0f);
                rigidBody.velocity = force * rigidBody.mass *
                                     (float) (0.25 * (int) (playerController.playerScore / 20000) + 1);

                // reset timer
                currentTimerValue = timerMaxTime;
            }
        }
    }

    private void UpdateTimerValueBasedOnScore()
    {
        var t = playerController.playerScore / 600;
        var vel = 2 - t * 0.1;

        if (vel < 0.3)
        {
            this.timerMaxTime = 0.25;
        }
        else
        {
            this.timerMaxTime = vel;
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