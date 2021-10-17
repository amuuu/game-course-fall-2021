using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysCount : MonoBehaviour
{
    public static int keysCounter = 0;
    Text keysCounterScore;

    // Start is called before the first frame update
    void Start()
    {
        keysCounterScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        keysCounterScore.text = "score: " + keysCounter;
    }
}
