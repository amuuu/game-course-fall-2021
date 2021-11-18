using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Quad1")
        {
            Time.timeScale = 0;
        }

        if(collider.name == "ComboMaker1")
        {
            if (collider.tag=="HeartCombo")
            {
                Debug.Log("HeartCombo");
                ////changes for score here
               
            }

            if (collider.tag == "BulletCombo")
            {
                Debug.Log("BulletCombo");
                ////changes for bullet here
               
            }

            Destroy(collider.gameObject);
        }
        

    }
    }
