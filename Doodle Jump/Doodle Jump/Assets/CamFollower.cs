using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{

    public Transform target;
    public float camspeed = 0.2f;
    Vector3 currspeed;
    public levelmaker levelmaker;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.y>transform.position.y)
        {
            var pos= new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, pos,ref currspeed, camspeed*Time.deltaTime);

        }
    }
}
