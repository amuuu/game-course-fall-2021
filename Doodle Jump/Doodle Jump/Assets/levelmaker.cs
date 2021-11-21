using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmaker : MonoBehaviour
{
    private float currentTimerValue;
    public GameObject platformPrefab;
    public int numberOfplats=1000;
    public float levelwidth=5f;
    public float minY=0.5f;
    public float maxY=1f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnpos=new Vector3();
        for (int i=1; i<=numberOfplats;i++)
        {
            
                spawnpos.y += Random.Range(minY, maxY);
                spawnpos.x= Random.Range(-levelwidth, levelwidth);
                Instantiate(platformPrefab, spawnpos,Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       

     }

    
  
}
