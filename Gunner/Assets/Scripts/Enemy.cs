using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float timeStamp = 3f;
    
    public float coolDown = 0.2f;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (timeStamp <= Time.time)
        {
            timeStamp = Time.time + coolDown;

            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
        
    }
}
