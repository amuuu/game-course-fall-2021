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
                teleport(Player, teleportDoorDist);
            }else
            {
                Debug.Log("You don't have the key");
            }
        }
    }

    public void teleport(GameObject obj, float teleDist)
    {
        float distFromTeleDoor = Vector3.Distance(obj.transform.position, transform.position);
        if (distFromTeleDoor < teleDist)
        {
            obj.SetActive(false);
            obj.transform.position = appearPoint.transform.position;
            obj.SetActive(true);
        }
    }
}
