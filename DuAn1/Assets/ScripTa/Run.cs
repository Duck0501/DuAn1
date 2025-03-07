using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    Vector2 direction;
    public float speed = 10f;
    public Animator anm1A;
    public Animator anm1B;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        direction.x = Input.GetAxisRaw("Fire1");
        direction.y = Input.GetAxisRaw("Fire2");
        direction.Normalize();

        if (direction.x != 0 || direction.y != 0)
        {
            TriggerAnimation();
        }
        else
        {
            StopAnimation();
        }



    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    public void TriggerAnimation()
    {
        anm1A.SetBool("Run1A", true);
        anm1B.SetBool("Run1B", true);
    }

    public void StopAnimation()
    {
        anm1A.SetBool("Run1A", false);
        anm1B.SetBool("Run1B", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
