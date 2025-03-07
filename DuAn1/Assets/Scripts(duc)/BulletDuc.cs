using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletDuc : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject effect_bullet;
    Rigidbody2D rb;
    public int scoreValue = 1;
    private Score score;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime);
        score = FindObjectOfType<Score>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            score.AddScore(scoreValue);
            Destroy(this.gameObject);
            GameObject effectbullet = Instantiate(effect_bullet, transform.position, Quaternion.identity);
            Destroy(effectbullet, 0.4f);

        }
    }
}
