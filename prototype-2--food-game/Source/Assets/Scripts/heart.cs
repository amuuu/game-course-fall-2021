using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heart : MonoBehaviour
{
    public static int heartAmount;
    private Text heartText;
    // Start is called before the first frame update
    void Start()
    {
        heartText = GetComponent<Text>();
        heartAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        heartText.text = "Your Heart : " + heartAmount;
    }
}
