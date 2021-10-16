using UnityEngine;

public class PortalController : MonoBehaviour
{
    public bool isSource;
    public GameObject otherPortal;
    private int keysNeeded = 1;
    public void TryTeleport(GameObject obj, int portalKeysCount=0)
    {
        if (!isSource) return;
        if (obj.CompareTag(TagNames.Character.ToString()) && portalKeysCount < keysNeeded)
            return;

        obj.transform.position = otherPortal.transform.position;
    }
}
