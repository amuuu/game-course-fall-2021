using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControl : MonoBehaviour
{
    public GameObject gameobj;
    public GameObject clone1;
    public GameObject clone2;
    public GameObject clone3;

    public static bool disabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
            gameobj.SetActive(false);
        else
            gameobj.SetActive(true);
        
    }
}
