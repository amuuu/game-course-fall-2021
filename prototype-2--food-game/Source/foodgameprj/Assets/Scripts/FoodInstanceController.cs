using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstanceController : MonoBehaviour
{
    public FoodItemConfig config;
    private Rigidbody rigidBody;

    private void Start()
    {
        // change mass based on config
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.mass = config.weight;

        // rotate randomly when instantiating
        transform.Rotate(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            Destroy(this.gameObject);
        }
    }
}
