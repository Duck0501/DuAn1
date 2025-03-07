using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3.5f;
    public Transform player;
    [SerializeField] GameObject[] Items;
    [SerializeField] float Rate = 10f;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("player");
        if (playerObject == null)
        {
            playerObject = FindObjectOfType<GameObject>();
        }
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.Log("Ko co player");
        }

    }

    void Update()
    {
        if (player != null)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
            if (Random.Range(0f, 100f) < Rate)
            {
                int randomIndex = Random.Range(0, Items.Length);
                Instantiate(Items[randomIndex], transform.position, Quaternion.identity);
            }
        }
    }
}
