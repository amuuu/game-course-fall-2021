using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneTeleport : MonoBehaviour
{
    private GameObject doorSource;
    private Vector3 direction;
    private float force;
    private float strengthOfAttraction;
    public float MIN_SIZE; 
    [SerializeField] GameObject doorDestination;
    // Start is called before the first frame update
    void Start()
    {
        MIN_SIZE = 0.015f;
        strengthOfAttraction = 35.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorSource)
        {
            direction =  doorSource.transform.position - transform.position ;
            force = (float)Math.Sqrt(Math.Pow(direction.x, 2) + Math.Pow(direction.y, 2) + Math.Pow(direction.z, 2));
            GetComponent<Rigidbody2D>().AddForce(strengthOfAttraction * new Vector2(1/force,1/force)*direction);
            if (Math.Abs(direction.sqrMagnitude) < MIN_SIZE)
            {
                Debug.Log(direction.sqrMagnitude+" < "+MIN_SIZE);
                transform.position =  doorDestination.transform.position;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DoorTeleS.ToString()))
        {
            doorSource = collision.gameObject;
            // transform.position =  doorDestination.transform.position;
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.DoorTeleS.ToString()))
        {
            doorSource = null;
            // transform.position =  doorDestination.transform.position;
        }
            
    }
    


}
