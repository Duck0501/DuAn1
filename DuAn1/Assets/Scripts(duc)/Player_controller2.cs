using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_controller2 : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] Transform firePoint;
    private Rigidbody2D rb;
    public float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 huongNhin = mousePos - transform.position;

        //float gocXoay = Mathf.Atan2(huongNhin.y, huongNhin.x) * Mathf.Rad2Deg - 90;
        //rb.rotation = gocXoay;
        Move();
        Attack();

    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        if (MathF.Abs(horizontal) > 0.1f)
        {
            rb.velocity = movement * speed * Time.deltaTime;
        }
        else if (Mathf.Abs(vertical) > 0.1f)
        {
            rb.velocity = movement * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }
}
