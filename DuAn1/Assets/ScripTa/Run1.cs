using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run1 : MonoBehaviour
{
    private Rigidbody2D rb1;
    private Vector2 direction1;
    public float speed1 = 10f;
    public Animator anm;

    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction1.x = Input.GetAxisRaw("Horizontal");
        direction1.y = Input.GetAxisRaw("Vertical");
        direction1.Normalize();

        
        
    }

    private void FixedUpdate()
    {
        rb1.velocity = direction1 * speed1;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            Destroy(gameObject);
        }

    }
    
}
