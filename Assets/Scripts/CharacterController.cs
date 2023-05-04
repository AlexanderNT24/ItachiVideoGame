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

    Transform bulletTransform;

    public bool isMovRight;
    public bool isMovLeft;
    public bool isMovJump;
    public bool isMovFire;


    public void ButtonRight(){
        isMovRight=true;
    }

    public void ButtonNoRight(){
        isMovRight=false;
    }

    public void ButtonLeft(){
        isMovLeft=true;
    }

    

    public void ButtonNoLeft(){
        isMovLeft=false;
    }

    public void ButtonJump(){
        isMovJump=true;
    }

    public void ButtonFire(){
        isMovFire=true;
    }



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

        if (Input.GetKey("d") || isMovLeft)
        {
            currentAnimation = 1;
            rb.velocity = new Vector2(4, velocityY);
            sr.flipX = false;
        }
        if (Input.GetKey("a") || isMovRight)
        {
            currentAnimation = 1;
            rb.velocity = new Vector2(-4, velocityY);
            sr.flipX = true;
        }
        if ((Input.GetKey("q") && Time.time > nextFireTime && pointController.puntos > 0) || isMovFire) 
        {

            isMovFire=false;
            nextFireTime = Time.time + fireRate; // Establecer el tiempo de espera hasta la siguiente bala

            var balaGO = Instantiate(bullet, firePoint.position, Quaternion.identity);
            var controller = balaGO.GetComponent<BulletController>();
            currentAnimation = 3;
            bulletTransform= balaGO.GetComponent<Transform>();
            

            pointController.SumarPuntos(-1); // Restar un punto por cada bala creada
        }

        if (Input.GetKeyDown("e") )
        {
            Debug.Log(bulletTransform.position);
            // Generar objeto en diagonal arriba-derecha
            GameObject balaGO = Instantiate(bullet, new Vector2(bulletTransform.position.x + 2, bulletTransform.position.y + 2), Quaternion.identity);
            balaGO.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 2f).normalized * 250f;

            // Generar objeto en diagonal abajo-izquierda
            GameObject balaGO2 = Instantiate(bullet, new Vector2(bulletTransform.position.x - 2, bulletTransform.position.y - 2), Quaternion.identity);
            balaGO2.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, -2f).normalized * 250f;
            (balaGO.GetComponent<BulletController>()).velocityY = 1;
            (balaGO2.GetComponent<BulletController>()).velocityY = -1;



            currentAnimation = 3;
        }

        if (Input.GetKeyUp(KeyCode.Space) || isMovJump)
        {
            isMovJump=false;
            currentAnimation = 2;
            rb.AddForce(transform.up * jumpForce);
        }
        animator.SetInteger("state", currentAnimation);
    }
}
