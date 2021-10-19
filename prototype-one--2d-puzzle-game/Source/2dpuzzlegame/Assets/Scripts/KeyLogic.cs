using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogic : MonoBehaviour
{
    private bool isDetected;
    public EventSystemCustom eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        isDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isDetected)
            {
                eventSystem.OnKeyEated.Invoke();
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            Debug.LogWarning("sticky");
            isDetected = true;
           
           
        }
        

       

    }

    
}
