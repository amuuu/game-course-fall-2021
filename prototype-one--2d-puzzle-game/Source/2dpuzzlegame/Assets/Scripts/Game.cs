using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text keyCounterText;
    public int collectedKeys = 0;
    
    public void onKeyCollected()
    {
        collectedKeys += 1;
        keyCounterText.text = collectedKeys.ToString();
    }
    
    public void onKeyUsed()
    {
        collectedKeys -= 1;
        keyCounterText.text = collectedKeys.ToString();
    }

}
