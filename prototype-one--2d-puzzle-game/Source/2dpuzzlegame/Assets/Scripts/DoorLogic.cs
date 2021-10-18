using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class DoorLogic : MonoBehaviour
{
    private bool inDoorArea;
    public GameObject WinMenu;
    public GameObject Level;
    [SerializeField] Text keysCollectedText;

    // Start is called before the first frame update
    void Start()
    {
        inDoorArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inDoorArea)
            {
                var text = keysCollectedText.text;
                text = text.Split(':')[1];
                var number = int.Parse(text);
                if (number == 3)
                {
                    WinMenu.SetActive(true);
                    Level.SetActive(false);
                }
                else
                {
                    Debug.Log("asaas");
                    StartCoroutine(ExampleCoroutine());
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            inDoorArea = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            inDoorArea = false;
        }
    }

    IEnumerator ExampleCoroutine()
    {
        keysCollectedText.color=Color.red;
        keysCollectedText.fontSize = 52;
        yield return new WaitForSeconds(0.5f);
        keysCollectedText.color=Color.white;
        keysCollectedText.fontSize = 35;
    }
}
