using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public float teleportDoorDist;

    public GameObject Player;
    public GameObject appearPoint;
    public GameObject destinationDoor;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Player.GetComponent<CollectItem>().teleportKeyNumber > 0)
            {
                float distFromTeleDoor = Vector3.Distance(Player.transform.position, transform.position);
                if (distFromTeleDoor < teleportDoorDist)
                {
                    Player.SetActive(false);
                    Player.transform.position = appearPoint.transform.position;
                    Player.SetActive(true);
                }
            }else
            {
                Debug.Log("You don't have the key");
            }
        }
    }
}
