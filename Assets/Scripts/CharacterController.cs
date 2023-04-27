using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;
    
    public int vidas;
    public Transform firePoint;
    public GameObject bullet;

    public float jumpForce = 300f;
    public float fireRate = 1f; // segundos entre creaciones de balas
    private float nextFireTime = 0f; // tiempo hasta que se pueda crear la próxima bala

    private int currentAnimation = 0;
    private PointController pointController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pointController = FindObjectOfType<PointController>();
    }

    void Update()
    {
        currentAnimation = 0;
        var velocityY = rb.velocity.y;
        rb.velocity = new Vector2(0, velocityY);

        if (Input.GetKey("d"))
        {
            currentAnimation = 1;
            rb.velocity = new Vector2(4, velocityY);
            sr.flipX = false;
        }
        if (Input.GetKey("a"))
        {
            currentAnimation = 1;
            rb.velocity = new Vector2(-4, velocityY);
            sr.flipX = true;
        }
        if (Input.GetKey("q") && Time.time > nextFireTime && pointController.puntos > 0)
        {
            nextFireTime = Time.time + fireRate; // Establecer el tiempo de espera hasta la siguiente bala

            var balaGO = Instantiate(bullet, firePoint.position, Quaternion.identity);
            var controller = balaGO.GetComponent<BulletController>();
            currentAnimation = 3;

            pointController.SumarPuntos(-1); // Restar un punto por cada bala creada
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentAnimation = 2;
            rb.AddForce(transform.up * jumpForce);
        }
        animator.SetInteger("state", currentAnimation);
    }
}
