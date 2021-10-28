using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstanceController : MonoBehaviour
{
    public FoodItemConfig config;
    public Rigidbody rigidBody;
    private PlayerController player;

    private void Start()
    {
        // change mass based on config
        rigidBody = GetComponent<Rigidbody>();
        //in my case, increasing the mass didn't do much difference in falling speed, that's why i changed it to drag instead
        rigidBody.drag = config.drag;

        // rotate randomly when instantiating
        transform.Rotate(0, Random.Range(-45, 45), 0);

        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill"))
        {
            Destroy(this.gameObject);
            player.LostOneFood();
        }
    }
}
