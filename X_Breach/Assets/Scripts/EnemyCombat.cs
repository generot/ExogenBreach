using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCombat : MonoBehaviour
{
    public LayerMask mask;
    public BaseEnemy b_enemy;

    bool attackFinished = true;
    float bulletSpeed = 4f;

    rcast rc;
    public GameObject bullet;

    void Start()
    {
        rc = new rcast(mask, b_enemy.dmg, b_enemy.shootingDistance);
    }

    void Update()
    {
        if(attackFinished)
        {
            attackFinished = false;
            StartCoroutine(Attack(b_enemy.delay));
        }
    }

    IEnumerator Attack(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector2 dir = rc.Hit(transform.position, transform.localScale, Vector2.left);

        if(dir != Vector2.zero)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
        }

        attackFinished = true;
    }

}
