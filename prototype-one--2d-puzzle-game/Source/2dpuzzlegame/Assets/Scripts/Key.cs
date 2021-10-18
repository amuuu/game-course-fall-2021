using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isCollectable;
    public Game game;

    public void start()
    {
        isCollectable = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (isCollectable)
            {
                game.onKeyCollected();
                isCollectable = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            isCollectable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            isCollectable = false;
        }
    }
}
