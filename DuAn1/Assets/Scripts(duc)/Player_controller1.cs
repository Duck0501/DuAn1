using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Player_controller1 : MonoBehaviour
{
    public GameObject BulletDefault;
    public GameObject BulletVip;
    private GameObject Bullet;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    Rigidbody2D rb;
    public float speed = 7f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Bullet = BulletDefault;
    }

    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 huongnhin = mousepos - transform.position;

        float gocxoay = Mathf.Atan2(huongnhin.y, huongnhin.x) * Mathf.Rad2Deg - 90;
        rb.rotation = gocxoay;

        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            isMoving = true;
        }
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }
    public void ChangeBullet(bool useBulletVip)
    {
        if (useBulletVip)
        {
            Bullet = BulletVip;
        }
        else
        {
            Bullet = BulletDefault;
        }
    }
    void Shoot()
    {
        GameObject bullett = Instantiate(Bullet, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullett.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;
    }
}
