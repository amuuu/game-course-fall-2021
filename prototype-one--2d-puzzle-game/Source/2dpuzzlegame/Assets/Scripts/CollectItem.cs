using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int keyNumber;       // Number of keys that we have collected
    public float distFromKey;   // Minimum distance from keys to be able to collect them
    public GameObject[] keys;   // Array of keys in the scene

    void Update()
    {
        // Check if the key is pressed or not
        if (Input.GetKeyDown(KeyCode.E)) // We use GetKeyDown, because we want just one time run
        {
            // Iterate on each key
            for (int i = 0; i < keys.Length; i++)
            {
                
                // Calculate player distance from keys in X Axis for each key
                float dist = Mathf.Abs(transform.position.x - keys[i].transform.position.x);

                // Check if the key is active or not and the distance is less than threshold
                if (dist < distFromKey && keys[i].activeSelf)
                {
                    // Deactivate the key that we collect
                    keys[i].SetActive(false);
                    // Increase number of keys that we have
                    keyNumber++;
                }
            }
        }
    }
}
