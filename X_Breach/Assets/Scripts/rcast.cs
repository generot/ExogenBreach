using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcast : BaseEntity
{
    float rayLen;
    LayerMask mask;

    public rcast(LayerMask _mask, int dmg, float len) 
        : base(0.1f, 6f, 0.3f, 100, dmg)
    {
        rayLen = len;
        mask = ~_mask;
    }

    public void Hit(Vector2 org, Vector2 scale)
    {
        Vector2 dir = Vector2.right * scale.normalized.x;
        RaycastHit2D hitInfo = Physics2D.Raycast(org, dir, rayLen, mask);

        if(hitInfo)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                Enemy enm = hitInfo.collider.GetComponent<Enemy>();

                Debug.Log("Enemy: " + enm.b_entity.health);
                enm.b_entity.TakeDamage(damage);
            } 
            
            if(hitInfo.collider.CompareTag("Player"))
            {
                pctrl pController = hitInfo.collider.GetComponent<pctrl>();

                Debug.Log("Player: " + pController.b_entity.health);
                pController.b_entity.TakeDamage(damage);
            }
        }
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
