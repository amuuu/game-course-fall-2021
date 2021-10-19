using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public Text stickyClonesText;
    public int collectedKeysCount;
    public Text collectedKeysText;
    public Text portalKeyText;
    public Text gameOverText;

    void Start()
    {
        eventSystem.OnKeyPickup.AddListener(UpdateKeyCountText);
        eventSystem.OnWinDoorInteract.AddListener(CheckForWinCondition);
        eventSystem.OnPlayerDeath.AddListener(UpdateLoseText);
        collectedKeysCount = 0;
    }

    public void UpdateStickyCloneText(int stickyClonesCount)
    {
        Debug.Log("UPDATE STICKY CLONE");
        stickyClonesText.text = "Sticky Clones: " + stickyClonesCount.ToString();
    }
    public void UpdateKeyCountText()
    {
        Debug.Log("UPDATE COLLECTED KEYS");
        collectedKeysCount++;
        collectedKeysText.text = "Collected Keys: " + collectedKeysCount.ToString();
    }
    public void UpdatePortalKeyText(int portalKeyCount)
    {
        Debug.Log("UPDATE PORTAL KEY");
        portalKeyText.text = "Portal Keys: " + portalKeyCount.ToString();
    }
    public void CheckForWinCondition(int requiredKeyCount)
    {
        if (collectedKeysCount >= requiredKeyCount)
        {
            Debug.Log("WIN");
            collectedKeysCount -= requiredKeyCount;
            collectedKeysText.text = "Collected Keys: " + collectedKeysCount.ToString();
            gameOverText.text = "You Won!";
        }
        else
        {
            Debug.Log("NOT ENOUGH KEYS");
        }
    }
    public void UpdateLoseText()
    {
        gameOverText.text = "You Lost!";
        gameOverText.color = Color.red;
    }
}
