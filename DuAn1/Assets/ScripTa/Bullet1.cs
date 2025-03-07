using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float BulletSpeed = 30f;
    [SerializeField] float lifetime = 1f;
    Rigidbody2D myRigidbody;
    Run Tank1;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Tank1 = FindObjectOfType<Run>();
        xSpeed = Tank1.transform.localScale.x * BulletSpeed;
        xSpeed = BulletSpeed;
        Destroy(gameObject, lifetime);
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Vach voi"))
    //    {
    //        Destroy(gameObject);
    //    }

    //    if (collision.CompareTag("Tank2"))
    //    {
    //        Destroy(gameObject);
    //    }


    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Vach voi"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Tank2"))
        {
            Destroy(gameObject);
        }
    }





}
