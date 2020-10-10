using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    //public pctrl pController;
    public LayerMask mask;
    public BaseEnemy b_enemy;

    rcast rc;
    //public Transform EnemySPoint;

    void Start()
    {
        rc = new rcast(mask, b_enemy.dmg, 1f);
    }

    void Update()
    {
        eShoot();
    }

    void eShoot()
    {
        //while(true)
        //{
            rc.Hit(transform.position, transform.localScale);
            //yield return new WaitForSeconds(b_enemy.delay);
        //}
    }
}
