using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public EventSystemCustom eventSystem;
    public int portalKeyCount;
    // Start is called before the first frame update
    void Start()
    {
        portalKeyCount = 0;
    }
}
