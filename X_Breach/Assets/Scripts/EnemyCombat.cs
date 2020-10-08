using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public pctrl pController;
    public LayerMask Target;
    public Transform EnemySPoint;

    public float range;
    public int dmg;
    void Update()
    {
        StartCoroutine(eShoot());
    }

    IEnumerator eShoot()
    {
        Collider2D[] target_array = Physics2D.OverlapCircleAll(EnemySPoint.position, range, Target);
        foreach (Collider2D hit in target_array)
        {
            if (hit.gameObject)
            {
                hit.gameObject.GetComponent<pctrl>().b_entity.TakeDamage(dmg);
                Debug.Log("Player has " + hit.gameObject.GetComponent<pctrl>().b_entity.health + " health");
            }

            yield return 10;
        }
    }
}
