using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public EventSystemCustom eventSystem;
    public UiManager uiManager;
    public int portalKeyCount;
    public int stickyClonesCount;
    public int keyCount;
    // Start is called before the first frame update
    void Start()
    {
        //if (FindObjectOfType<EventSystemCustom>() == null)
        //{
        //    Debug.LogWarning("FindObjectOfType<EventSystemCustom>() is null");
        //}
        //eventSystem = FindObjectOfType<EventSystemCustom>();
        //if (eventSystem == null)
        //{
        //    Debug.LogWarning("event system is null");
        //}
        eventSystem.OnCloneStickyPlatformEnter.AddListener(OnCloneStickyPlatformEnter);
        eventSystem.OnKeyPickup.AddListener(OnKeyPickup);
        eventSystem.OnWinDoorInteract.AddListener(OnWinDoorInteract);
        eventSystem.OnPortalKeyPickup.AddListener(OnPortalKeyPickup);
        eventSystem.OnPortalInteract.AddListener(OnPortalInteract);
        stickyClonesCount = 0;
        keyCount = 0;
        portalKeyCount = 0;
    }

    private void OnCloneStickyPlatformEnter()
    {
        stickyClonesCount++;
        uiManager.UpdateStickyCloneText(stickyClonesCount);
    }
    public void OnKeyPickup()
    {
        keyCount++;
        uiManager.UpdateKeyText(keyCount);
    }
    public void OnWinDoorInteract(int requiredKeyCount)
    {
        if (keyCount >= requiredKeyCount)
        {
            Debug.Log("WIN");
            keyCount -= requiredKeyCount;
            uiManager.UpdateKeyText(keyCount);
            uiManager.UpdateWinText();
        }
        else
        {
            Debug.Log("NOT ENOUGH KEYS");
        }
    }
    public void OnPortalKeyPickup()
    {
        portalKeyCount++;
        uiManager.UpdatePortalKeyText(portalKeyCount);
    }
    public void OnPortalInteract()
    {
        if (portalKeyCount >= 1)
        {
            portalKeyCount--;
            uiManager.UpdatePortalKeyText(portalKeyCount);
            eventSystem.OnPlayerTeleport.Invoke();
        }
    }
}
