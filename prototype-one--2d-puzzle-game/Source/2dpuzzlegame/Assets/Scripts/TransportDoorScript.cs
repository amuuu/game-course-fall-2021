using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportDoorScript : MonoBehaviour
{
    public string type;
    public GameObject CoDoor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isNearPlayer(Transform playerTransform)
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        // Debug.Log(distance);
        if (distance <= 0.2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void transportPlayer(Transform playerTransform)
    {
        playerTransform.position = CoDoor.GetComponent<Transform>().position;
    }
    
}
