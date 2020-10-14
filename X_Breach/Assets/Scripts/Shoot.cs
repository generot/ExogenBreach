using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public LayerMask mask;
    public GameObject bullet;

    public float bulletSpeed = 30f, cooldown = .05f;

    bool shotOnce = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !shotOnce)
        {
            shotOnce = true;
            StartCoroutine(ShootBullet());
        }
    }

    IEnumerator ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * transform.localScale.normalized * bulletSpeed;

        yield return new WaitForSeconds(cooldown);

        shotOnce = false;
    }
}
