using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float BulletSpeed = 30f;
    [SerializeField] float lifetime = 1f;
    Rigidbody2D myRigidbody;
    Run1 Tank2;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Tank2 = FindObjectOfType<Run1>();
        xSpeed = Tank2.transform.localScale.x * BulletSpeed;
        xSpeed = -BulletSpeed;
        Destroy(gameObject, lifetime);
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Vach voi"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Tank1"))
        {
            Destroy(gameObject);
        }
    }





}
