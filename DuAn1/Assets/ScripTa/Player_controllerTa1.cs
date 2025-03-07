using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controllerTa1 : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 huongNhin = mousePos - transform.position;

        float gocXoay = Mathf.Atan2(huongNhin.y, huongNhin.x) * Mathf.Rad2Deg - 90;
        rb.rotation = gocXoay;
    }
}