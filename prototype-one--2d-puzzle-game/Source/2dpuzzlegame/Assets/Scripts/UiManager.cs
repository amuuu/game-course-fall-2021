using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public int stickyClonesCount;
    public Text stickyClonesText;
    public int collectedKeysCount;
    public Text collectedKeysText;

    void Start()
    {
        eventSystem.OnCloneStickyPlatformEnter.AddListener(UpdateStickyCloneText);
        eventSystem.OnKeyPickup.AddListener(UpdateKeyCountText);
        eventSystem.OnWinDoorInteract.AddListener(CheckForWinCondition);
        stickyClonesCount = 0;
        collectedKeysCount = 0;
    }

    public void UpdateStickyCloneText()
    {
        Debug.Log("UPDATE STICKY CLONE");
        stickyClonesCount++;
        stickyClonesText.text = "Sticky Clones: " + stickyClonesCount.ToString();
    }
    public void UpdateKeyCountText()
    {
        Debug.Log("UPDATE COLLECTED KEYS");
        collectedKeysCount++;
        collectedKeysText.text = "Collected Keys: " + collectedKeysCount.ToString();
    }
    public void CheckForWinCondition(int requiredKeyCount)
    {
        if (collectedKeysCount >= requiredKeyCount)
        {
            Debug.Log("WIN");
            collectedKeysCount -= requiredKeyCount;
            collectedKeysText.text = "Collected Keys: " + collectedKeysCount.ToString();
        }
        else
        {
            Debug.Log("NOT ENOUGH KEYS");
        }
    }
}
