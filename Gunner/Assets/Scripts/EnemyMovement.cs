using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int randomPoint;
    private Vector3 offset;
    private int randomZ;
    private Vector3 flyPoint;
    public ShipMove movePoints;
    public int speed = 10;

    void Start()
    {
        movePoints = GameObject.Find("Ship").GetComponent <ShipMove>();
        randomPoint = Random.Range(0, 22);
        randomZ = Random.Range(-40, 40);
        offset = new Vector3(0, 0, randomZ);
        flyPoint = new Vector3(0,0,0);
        flyPoint += (movePoints.moveTarget[randomPoint].transform.position) + offset;

    }

    void Update()
    {
        transform.LookAt(flyPoint);
        transform.position = Vector3.MoveTowards(transform.position, flyPoint, speed * Time.deltaTime);

        if(transform.position == flyPoint)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
