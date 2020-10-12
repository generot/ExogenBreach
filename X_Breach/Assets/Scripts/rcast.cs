using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast
{
    int damage;
    float rayLen;

    LayerMask mask;

    public rcast(LayerMask _mask, int dmg, float len) 
    {
        rayLen = len;
        mask = _mask;
        damage = dmg;
    }

    public Vector2 Hit(Vector2 org, Vector2 scale, Vector2 mult)
    {
        Vector2 dir = mult * scale.normalized.x;
        RaycastHit2D hitInfo = Physics2D.Raycast(org, dir, rayLen, mask);

        if(hitInfo)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                Enemy enm = hitInfo.collider.GetComponent<Enemy>();

                Debug.Log("Enemy: " + enm.b_entity.health);
                enm.b_entity.TakeDamage(damage);
            } 
            else if(hitInfo.collider.CompareTag("Player"))
            {
                pctrl enm = hitInfo.collider.GetComponent<pctrl>();

                Debug.Log("Player: " + enm.b_entity.health);
                enm.b_entity.TakeDamage(damage);
            }
            return (Vector2)hitInfo.transform.position - org;
        }

        return Vector2.zero;
    }

    /*IEnumerator shoot(Transform transform, Vector2 Pos)
    { 
        RaycastHit2D enemyInf = Physics2D.Raycast(transform.position, Pos, units);
        if (enemyInf && enemyInf.collider.CompareTag("Enemy")) {
            Enemy hostile = enemyInf.transform.GetComponent<Enemy>();
            if (hostile != null)
            {
                hostile.b_entity.TakeDamage(damage);
                Debug.Log(hostile.b_entity.health);
                yield return 0; //for now because its a coroutine, but later because it will be an animation :)

                if (hostile.b_entity.health <= 0)
                {
                    yield return 0; //same as ^
                    Destroy(hostile.gameObject, 0);
                }
            }
        }
    }*/
}
