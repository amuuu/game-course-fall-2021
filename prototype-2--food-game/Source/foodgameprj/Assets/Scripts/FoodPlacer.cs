using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    private List<GameObject> combos = new List<GameObject>();
    private List<GameObject> foods = new List<GameObject>();

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
                    else if (comboP > 40 && playerController.playerHealth < 3)
                    {
                        go = Instantiate(comboPrefabs[2]);
                    }
                    else
                    {
                        go = Instantiate(comboPrefabs[1]);
                    }

                    this.combos.Add(go);
                }
                else
                {
                    go = Instantiate(prefabs[GetRandomPrefabType(prefabs.Length)]);
                    this.foods.Add(go);
                }

                go.transform.position =
                    new Vector3(GetRandomPrefabInitialX(), transform.position.y, transform.position.z);

                // reset timer
                currentTimerValue = timerMaxTime;

                UpdateTimerValueBasedOnScore();
            }

            foreach (var food in this.foods)
            {
                var rigidBody = food.GetComponent<Rigidbody>();
                Vector3 force = new Vector3(0.0f, -1.0f, 0.0f);
                // rigidBody.velocity =
                // (force * rigidBody.mass * (float) (0.25 * (int) (playerController.playerScore / 20000) + 1)) /
                // (playerController.freeze * 10 - 9);
                food.AddComponent<Rigidbody>().velocity =
                    (force * rigidBody.mass * (float) (0.25 * (int) (playerController.playerScore / 20000) + 1)) /
                    (playerController.freeze * 100 - 99);
            }

            foreach (var combo in this.foods)
            {
                var rigidBody = combo.GetComponent<Rigidbody>();
                Vector3 force = new Vector3(0.0f, -1.0f, 0.0f);
                // rigidBody.velocity =
                // (force * rigidBody.mass * (float) (0.25 * (int) (playerController.playerScore / 20000) + 1)) /
                // (playerController.freeze * 10 - 9);
                combo.AddComponent<Rigidbody>().velocity =
                    (force * rigidBody.mass * (float) (0.25 * (int) (playerController.playerScore / 20000) + 1)) /
                    (playerController.freeze * 100 - 99);
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