using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_controller3 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
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
}
