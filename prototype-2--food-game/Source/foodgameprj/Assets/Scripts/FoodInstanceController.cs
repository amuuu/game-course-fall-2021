using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodInstanceController : MonoBehaviour
{
    public FoodItemConfig config;
    private Rigidbody rigidBody;
    public PlayerController player;

    private void Start()
    {
        // change mass based on config
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.mass = config.weight;
        Vector3 force = new Vector3(0.0f, -1.0f, 0.0f);
        rigidBody.velocity = force * rigidBody.mass;

        // rotate randomly when instantiating
        transform.Rotate(0, Random.Range(-45, 45), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            Destroy(this.gameObject);
        }
    }

}