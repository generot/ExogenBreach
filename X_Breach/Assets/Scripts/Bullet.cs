using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GetComponentInParent<pctrl>())
            Destroy(gameObject);

        if (collision.tag == "Enemy" && !GetComponentInParent<Enemy>())
            Destroy(gameObject);
    }
}
