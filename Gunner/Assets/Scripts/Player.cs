using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float force;
    public Transform shootPoint;
    public GameObject ship;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Moved this to class scope so that I can use it in OnDrawGizmos
    private Vector3 aim;

    // Update is called once per frame
    void Update()
    {
        // NewInputs version of Input.mousePosition;
        Vector3 mousePos = Input.mousePosition;
        mousePos += ship.transform.forward * 100f;
        aim = mainCamera.ScreenToWorldPoint(mousePos);
        
        // Draw a line so we can see where we are aiming at
        Debug.DrawLine(shootPoint.position, aim, Color.blue);

        // NewInputs version of Input.GetKeyDown(KeyCode.Mouse0)
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            bullet.transform.LookAt(aim);

            Rigidbody b = bullet.GetComponent<Rigidbody>();
            b.AddRelativeForce(bullet.transform.forward * force);
        }
    }

    private void OnDrawGizmos()
    {
        // Yellow sphere is where the bullets spawn
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(shootPoint.position, 0.1f);
        // Red sphere is where they are going
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(aim, 0.25f);
    }
}