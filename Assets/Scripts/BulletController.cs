using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float velocityX = 250f;
    public float velocityY = 0;
    public int a;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }


    void Update()
    {
        rb.velocity = new Vector2(+velocityX, velocityY);
        Destroy(this.gameObject,5f);
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.tag);
        Destroy(this.gameObject);
        if (collision.gameObject.tag == "Enemy") 
        {
            Time.timeScale = 0;
        Destroy(collision.gameObject);
        
        }
        if (collision.gameObject.tag == "EnemyBullet") 
        {
            FindObjectOfType<KillsController>().AddKill();

        
        }
    }
}
