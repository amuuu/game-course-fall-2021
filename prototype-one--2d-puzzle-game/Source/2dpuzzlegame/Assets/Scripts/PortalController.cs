using UnityEngine;

public class PortalController : MonoBehaviour
{
    public bool isSource;
    public GameObject otherPortal;
    public TextMesh KeysNeededText;
    public SpriteRenderer KeyIcon;
    private int keysNeeded = 1;
    public EventSystemCustom eventSystem;

    void Start()
    {
        if (isSource)
        {
            KeysNeededText.gameObject.SetActive(true);
            KeyIcon.gameObject.SetActive(true);

            KeysNeededText.text = keysNeeded.ToString();
            eventSystem.OnPortalKeyPickup.AddListener(UpdateKeysNeededColor);
        }
    }
    public bool TryTeleport(GameObject obj, int portalKeysCount=0)
    {
        if (!isSource) return false;
        if (obj.CompareTag(TagNames.Character.ToString()) && portalKeysCount < keysNeeded)
            return false;

        obj.transform.position = otherPortal.transform.position;
        return true;
    }

    void UpdateKeysNeededColor(int keyCount){
        if(keyCount >= keysNeeded){
            KeysNeededText.color = Color.green;
            KeyIcon.color = Color.green;
        }
        else{
            KeysNeededText.color = Color.red;
            KeyIcon.color = Color.red;
        }
    }
}
