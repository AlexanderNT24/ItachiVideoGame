using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarutoController : MonoBehaviour
{


    public Transform firePoint;
    public GameObject bullet;

    public float fireRate = 3f; // segundos entre creaciones de balas
    private float nextFireTime = 0f; // tiempo hasta que se pueda crear la próxima bala

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // Establecer el tiempo de espera hasta la siguiente bala

            var balaGO = Instantiate(bullet, firePoint.position, Quaternion.identity);
            var controller = balaGO.GetComponent<BulletController>();

        }


    }
}
