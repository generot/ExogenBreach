using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public LayerMask mask;
    public BaseEnemy b_enemy;

    bool attackFinished = true;

    rcast rc;
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
        rc.Hit(transform.position, transform.localScale, Vector2.left);

        attackFinished = true;
    }

}
