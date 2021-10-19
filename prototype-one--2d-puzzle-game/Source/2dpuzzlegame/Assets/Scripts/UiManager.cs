using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public EventSystemCustom eventSystem;

    public Text stickyClonesText;
    public Text collectedKeysText;
    public Text portalKeyText;
    public Text gameOverText;

    void Start()
    {
        eventSystem.OnPlayerDeath.AddListener(UpdateLoseText);
    }

    public void UpdateStickyCloneText(int stickyClonesCount)
    {
        Debug.Log("UPDATE STICKY CLONE");
        stickyClonesText.text = "Sticky Clones: " + stickyClonesCount.ToString();
    }
    public void UpdateKeyText(int keyCount)
    {
        Debug.Log("UPDATE KEY");
        collectedKeysText.text = "Collected Keys: " + keyCount.ToString();
    }
    public void UpdatePortalKeyText(int portalKeyCount)
    {
        Debug.Log("UPDATE PORTAL KEY");
        portalKeyText.text = "Portal Keys: " + portalKeyCount.ToString();
    }
    public void UpdateWinText()
    {
        gameOverText.text = "You Won!";
        gameOverText.color = Color.green;
    }
    public void UpdateLoseText()
    {
        gameOverText.text = "You Lost!";
        gameOverText.color = Color.red;
    }
}
