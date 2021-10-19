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
        eventSystem.OnPortalKeyPickup.AddListener(OnPortalKeyPickup);
        eventSystem.OnPortalInteract.AddListener(OnPortalInteract);
        eventSystem.OnCloneStickyPlatformEnter.AddListener(OnCloneStickyPlatformEnter);
        stickyClonesCount = 0;
        portalKeyCount = 0;
    }

    private void OnCloneStickyPlatformEnter()
    {
        stickyClonesCount++;
        uiManager.UpdateStickyCloneText(stickyClonesCount);
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
    public void OnPortalKeyPickup()
    {
        portalKeyCount++;
        uiManager.UpdatePortalKeyText(portalKeyCount);
    }
}
