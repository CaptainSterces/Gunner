using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public Transform[] moveTarget = new Transform[22];
    public Transform aimAt;
    public float speed = 10.0f;
    
    private int x = 0;

    void Start()
    {
 
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget[x].position, speed * Time.deltaTime);
        transform.LookAt(aimAt);
        if (transform.position == moveTarget[x].position)
        {
            x++;
            if(x == 22)
            {
                x = 0;
            }
        }
    }
}
