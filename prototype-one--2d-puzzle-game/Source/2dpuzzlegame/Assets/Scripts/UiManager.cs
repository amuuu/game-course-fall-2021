using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text counterText;
    public EventSystemCustom eventSystem;
    public int collectedKeysCount;
    public Text collectedKeysText;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateScoreText);
        eventSystem.OnKeyPickup.AddListener(UpdateKeyCountText);
        collectedKeysCount = 0;
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        int newTextValue = int.Parse(counterText.text) + 1;
            counterText.text = newTextValue.ToString();
    }
    public void UpdateKeyCountText()
    {
        Debug.Log("UPDATE COLLECTED KEYS");
        collectedKeysCount++;
        collectedKeysText.text = collectedKeysCount.ToString();
    }
}
