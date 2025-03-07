using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandan : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Gun;
    [SerializeField] float shootCooldown = 1f;
    private float nextShootTime = 0.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootCooldown;
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, Gun.position, transform.rotation);
    }
}
