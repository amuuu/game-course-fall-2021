using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Player;
    public GameObject appearPoint;

    private bool inTeleportZone;

    void Start()
    {
        inTeleportZone = false;
    }

    void Update()
    {
        if (inTeleportZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Player.GetComponent<CollectItem>().teleportKeyNumber > 0)
                {
                    teleport(Player);
                }
                else
                {
                    Debug.Log("You don't have the key");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.MainPlayer.ToString()))
        {
            inTeleportZone = true;
        }
        if (collision.gameObject.CompareTag(TagNames.ClonePlayer.ToString()))
        {

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.MainPlayer.ToString()))
        {
            inTeleportZone = false;
        }
    }

    public void teleport(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = appearPoint.transform.position;
        obj.SetActive(true);   
    }
}
