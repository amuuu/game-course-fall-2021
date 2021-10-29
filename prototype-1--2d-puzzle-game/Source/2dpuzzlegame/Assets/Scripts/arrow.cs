using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public GameObject gameObj;//the gameobject you want to disable in the scene

    // Start is called before the first frame update
    void Start()
    {
        gameObj.SetActive(true); //set the object to active
        gameObject.SetActive(true);//change the state of the current gameobject to active

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);//change the state of the current gameobject to active

        gameObj.SetActive(true); //set the object to active

    }
}
