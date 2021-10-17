using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject chooseText;

    private bool inChangeZone;

    void Start()
    {
        inChangeZone = false;
    }

    void Update()
    {
        if (inChangeZone && Player.GetComponent<CollectItem>().switchKeyNumber > 0)
        {
            chooseText.SetActive(true);
            Player.GetComponent<PlayerMove>().enabled = false;
        }else
        {
            chooseText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.MainPlayer.ToString()))
        {
            inChangeZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.MainPlayer.ToString()))
        {
            inChangeZone = false;
        }
    }
}
