using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public BaseEnemy enm;
    public GameObject player;

    void Update()
    {
        StartCoroutine(WaitAndShoot());
    }

    void Shoot()
    {
        if (player)
        {
            Vector2 dir = player.transform.position - transform.position;
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, dir, enm.shootingDistance);

            if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player")
                && hitInfo.collider.gameObject.GetComponent<pctrl>().b_entity.health > 0)
            {
                player.GetComponent<pctrl>().b_entity.TakeDamage(enm.dmg);
                Debug.Log("Player health is: " + player.GetComponent<pctrl>().b_entity.health + " hitpoints");
            }
        }
    }

    IEnumerator WaitAndShoot()
    {
        Shoot();
        yield return new WaitForSeconds(enm.delay);
    }
}
