using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandan1 : MonoBehaviour
{
    [SerializeField] GameObject Bullet1;
    [SerializeField] Transform Gun1;
    [SerializeField] float shootCooldown = 1f;
    private float nextShootTime = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootCooldown;
        }
    }

    void Shoot()
    {
        Instantiate(Bullet1, Gun1.position, transform.rotation);
    }
}
