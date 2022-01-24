using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowKey : MonoBehaviour
{
    private bool touchKey;
    public EventSystemCustom eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        touchKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
            if (touchKey)
            {
                touchKey = false;
                eventSystem.OnEatYellowKeyEvent.Invoke();
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("User"))
            touchKey = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("User"))
            touchKey = false;
    }
}