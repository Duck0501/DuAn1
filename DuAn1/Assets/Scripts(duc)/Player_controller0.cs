using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 7f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    public int HP = 5;
    public TextMeshProUGUI HPText;
    private bool Damage = true;
    public float Cooldown = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HPText.SetText(HP.ToString());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            isMoving = true;

            Vector3 direction = targetPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
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
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy") && Damage)
        {
            StartCoroutine(TakeDamage());
        }       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hp"))
        {
            HP++;
            HPText.SetText(HP.ToString());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("bullet2"))
        {
            Player_controller1 playerController1 = FindObjectOfType<Player_controller1>();
            if (playerController1 != null)
            {
                playerController1.ChangeBullet(true);
            }
            Destroy(collision.gameObject);
            StartCoroutine(ResetBullet(10f));
        }
    }

    private IEnumerator TakeDamage()
    {
        Damage = false;
        HP--;
        HPText.SetText(HP.ToString());
        if (HP == 0)
        {
            SceneManager.LoadScene("Game over(duc)");
        }
        yield return new WaitForSeconds(Cooldown);
        Damage = true;
    }
    private IEnumerator ResetBullet(float reset)
    {
        yield return new WaitForSeconds(reset);
        Player_controller1 playerController1 = FindObjectOfType<Player_controller1>();
        if (playerController1 != null)
        {
            playerController1.ChangeBullet(false);
        }
    }
}
