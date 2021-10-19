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
    public Text switchText;

    void Start()
    {
        eventSystem.OnPlayerDeath.AddListener(UpdateLoseText);
        eventSystem.OnCloneSwitchMode.AddListener(EnableSwitchText);
        eventSystem.OnExitCloneSwitchMode.AddListener(DisableSwitchText);

        DisableSwitchText();
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
    public void EnableSwitchText()
    {
        switchText.text = "Choose the new player amongst the clones.";
    }
    public void DisableSwitchText()
    {
        switchText.text = "";
    }
}
