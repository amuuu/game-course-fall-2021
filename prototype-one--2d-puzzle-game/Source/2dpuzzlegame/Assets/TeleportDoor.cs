using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSource;
    public TeleportDoor Dest;

    public void SendObjectToDest(GameObject obj)
    {
        obj.transform.position = Dest.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isSource && collision.gameObject.GetComponent<CloneMove>() != null) //collided with a clone
        {
            SendObjectToDest(collision.gameObject);
        }
    }
}
