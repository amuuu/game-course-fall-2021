using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int keyNumber;           // Number of keys that we have collected
    public float distFromKey;       // Maximum distance from keys to be able to collect them
    public int teleportKeyNumber;   // Number of keys that allows you to open teleport door
    public GameObject[] keys;       // Array of keys in the scene
    public EventSystemCustom eventSystem;

    void Update()
    {
        // Check if the key is pressed or not
        if (Input.GetKeyDown(KeyCode.E)) // We use GetKeyDown, because we want just one time run
        {
            // Iterate on each key
            for (int i = 0; i < keys.Length; i++)
            {
                // Calculate player distance from keys in X Axis for each key
                float dist = Vector3.Distance(keys[i].transform.position, transform.position);
                // Check if the key is active or not and the distance is less than threshold
                if ((dist < distFromKey && keys[i].activeSelf))
                {
                    // Deactivate the key that we collect
                    keys[i].SetActive(false);
                    // Increase number of keys that we have
                    keyNumber++;
                    if (keys[i].CompareTag(TagNames.TeleKey.ToString()))
                    {
                        teleportKeyNumber++;
                    }
                    // Invoke increase key number text signal
                    eventSystem.onGetKey.Invoke();
                }
            }
        }
    }
}
