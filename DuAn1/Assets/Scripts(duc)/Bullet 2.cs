using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    public float lifeTime;
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
        }
    }
}
