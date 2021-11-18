using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] ob;
    public Transform camPos;
    // Start is called before the first frame update
    void Start()
    {
        ObstacleMaker();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * PlayerPrefs.GetInt("speed") * Time.deltaTime);
        GameObject cs = GameObject.Find("Quad1");
        if (camPos.position.x - cs.transform.position.x > 25)
        {
            Destroy(cs);
        }
    }

    void ObstacleMaker()
    {
        var rand = Random.Range(0, ob.Length);
        GameObject clone = (GameObject)Instantiate(ob[rand], transform.position, Quaternion.identity);
        clone.name = "Quad1";
        clone.AddComponent<BoxCollider2D>();
        clone.GetComponent<BoxCollider2D>().isTrigger = true;
        float xx = Random.Range(0, 5);
        Invoke("ObstacleMaker", xx);

    }
}
