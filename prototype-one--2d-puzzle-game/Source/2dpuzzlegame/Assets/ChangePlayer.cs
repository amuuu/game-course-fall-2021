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
        if (inChangeZone)
        {
            Debug.Log("Here");
            chooseText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag(TagNames.SwitchZone.ToString()))
        ///{
           // Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        //}
    }
}
