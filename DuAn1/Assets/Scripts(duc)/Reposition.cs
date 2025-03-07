using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    public Vector2 campos;
    public Vector2 dir;

    void Update()
    {
        campos = Camera.main.transform.position;
        dir.x = campos.x - transform.position.x;
        dir.y = campos.y - transform.position.y;

        if (dir.x > 29)
        {
            transform.Translate(Vector2.right * 29 * 2);
        }
        else if (dir.x < -29)
        {
            transform.Translate(Vector2.right * -29 * 2);
        }
        else if (dir.y > 16)
        {
            transform.Translate(Vector2.up * 16 * 2);
        }
        else if (dir.y < -16)
        {
            transform.Translate(Vector2.up * -16 * 2);
        }
    }
}
