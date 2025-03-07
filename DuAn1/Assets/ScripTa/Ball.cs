using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float ms;
    //public TextMeshProUGUI ScoreTxt;
    //public TextMeshProUGUI ScoreTxt1;
    //[SerializeField] int score = 0;
    //[SerializeField] int score1 = 0;

    Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ms = 1f;
        initialPosition = transform.position;

        //ScoreTxt.text = score.ToString();
        //ScoreTxt1.text = score1.ToString();
    }

    void Update()
    {
        if (rb.velocity.magnitude > ms)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, ms * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      

        if (collision.CompareTag("Vach voi"))
        {
            
            StartCoroutine(ResetBallAfterDelay(0f));
        }
    }

    IEnumerator ResetBallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetBallPosition();
    }

    void ResetBallPosition()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = initialPosition;
    }
}

