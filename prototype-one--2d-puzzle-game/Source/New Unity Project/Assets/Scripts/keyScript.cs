using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
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
}
