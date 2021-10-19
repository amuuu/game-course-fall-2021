using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    private bool OnDoor;
    public EventSystemCustom eventSystem;
    private int counter;
    
    public GameObject WinMassage;
    public GameObject Level;
  
    void Start()
    {
        OnDoor = false;
        counter = 0; 
        eventSystem.OnKeyEated.AddListener(UpdateKeyEatedScore);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (OnDoor)
            {
                eventSystem.Door.Invoke();
                if (counter >= 2 )
                {
                    counter -= 3;
                    Debug.Log(counter);
                    
                    WinMassage.SetActive(true);
                    Level.SetActive(false);
                    
                    

                }
                
            }
        }
         
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Character.ToString()))
        {
            Debug.LogWarning("Door Open");
            OnDoor = true;
           
           
        }
        
    }
    
    public void UpdateKeyEatedScore()
    {
        counter++;
        Debug.Log("UPDATE SCORE");
        
    }
}
