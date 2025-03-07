using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDuc1 : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject effect_bullet;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);          
            GameObject effectbullet = Instantiate(effect_bullet, transform.position, Quaternion.identity);
            Destroy(effectbullet, 0.5f);

            var name = other.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
        }
        if (other.gameObject.CompareTag("block"))
        {
            Destroy(this.gameObject);
            GameObject effectbullet = Instantiate(effect_bullet, transform.position, Quaternion.identity);
            Destroy(effectbullet, 0.5f);
        }
        if (other.gameObject.CompareTag("hegde"))
        {
            Destroy(this.gameObject);
            GameObject effectbullet = Instantiate(effect_bullet, transform.position, Quaternion.identity);
            Destroy(effectbullet, 0.5f);
        }
    }
}
