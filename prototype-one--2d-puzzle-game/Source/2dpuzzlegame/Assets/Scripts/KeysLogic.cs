using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysLogic : MonoBehaviour
{
    private bool inKeyArea;
    [SerializeField] private int keyCollected;

    [SerializeField] Text keysCollectedText;

    // Start is called before the first frame update
    void Start()
    {
        inKeyArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (inKeyArea)
            {
                keyCollected++;
                inKeyArea = false;

                var text = keysCollectedText.text;
                text = text.Split(':')[1];
                var number = int.Parse(text) + 1;
                Debug.Log(number);
                keysCollectedText.text="Keys:" + (number);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            inKeyArea = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            inKeyArea = false;
        }
    }
}