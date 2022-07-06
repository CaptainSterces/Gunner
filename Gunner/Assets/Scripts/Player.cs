using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float force;
    public Transform shootPoint;
    public GameObject ship;
    public int Ammo = 50;
    //public GameObject gunEnd;


    private float coolDown = 0.2f;
    private float canFire;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    
    private Vector3 aim;

    
    void Update()
    {
        //gunEnd.transform.LookAt(aim);
        Vector3 mousePos = Input.mousePosition;
        aim = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.farClipPlane));

        
        Debug.DrawLine(shootPoint.position, aim, Color.blue);

        
        if ((Input.GetKey(KeyCode.Mouse0)) && canFire <= Time.time && Ammo > 0)
        {
            canFire = coolDown + Time.time;

            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            bullet.transform.LookAt(aim);

            Rigidbody b = bullet.GetComponent<Rigidbody>();
            b.AddRelativeForce(bullet.transform.forward * force);

            Ammo--;

            if(Ammo == 0)
            {
                StartCoroutine(ReloadAmmo());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(shootPoint.position, 0.1f);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(aim, 0.25f);
    }

    private IEnumerator ReloadAmmo() 
    {
        yield return new WaitForSeconds(4);
        Ammo = 50;
    }
}