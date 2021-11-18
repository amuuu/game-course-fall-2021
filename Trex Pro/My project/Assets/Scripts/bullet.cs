using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletspeed = 0.05f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        transform.Translate(Vector3.right * PlayerPrefs.GetInt("speed") * Time.deltaTime  + transform.right * bulletspeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Quad1")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Land")
        {
            Destroy(gameObject);
        }

       

    }


}
