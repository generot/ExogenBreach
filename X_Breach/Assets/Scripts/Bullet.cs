using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && transform.name == "fromEnemy")
            Destroy(gameObject);

        if (collision.tag == "Enemy" && transform.name == "fromPlayer")
        {
            collision.GetComponent<Enemy>().b_entity.TakeDamage(20);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                transform.name = "fromPlayer";
                break;
            case "Enemy":
                transform.name = "fromEnemy";
                break;
        }
    }
}
