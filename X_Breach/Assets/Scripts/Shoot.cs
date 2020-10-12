using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public LayerMask mask;
    public GameObject bullet;

    int damage = 20;
    float range = 8f, bulletSpeed = 4f;

    rcast ray;

    void Start()
    {
        ray = new rcast(mask, damage, range);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) /*&& !shotOnce*/)
        {
            //Vector2 dir = ray.Hit(transform.position, transform.localScale, Vector2.left);

            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation, transform);
            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * transform.localScale.normalized * bulletSpeed;
            //shotOnce = true;
        }

        //if (Input.GetMouseButtonUp(0)) ;
            //shotOnce = false;
    }
}
